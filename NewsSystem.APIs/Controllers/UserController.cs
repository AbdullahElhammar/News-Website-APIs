using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewsSystem.BL.DTOs.User.Login;
using NewsSystem.BL.DTOs.User.Register;
using NewsSystem.DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewsSystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;

        public UserController(IConfiguration configuration, UserManager<User> userManager)
        {
            this.configuration = configuration;
            this.userManager= userManager;
        }

        [HttpPost]
        [Route("Login")]
        public async  Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {
            #region UserName & Password Verification
            User? user = await userManager.FindByNameAsync(credentials.UserName);
            if (user is null)
            {
                return Unauthorized();
            }
            bool IsPasswordCorrect = await userManager.CheckPasswordAsync(user, credentials.Password);
            if (!IsPasswordCorrect)
            {
                return Unauthorized();
            }
            #endregion

            #region Generate Token
            var ClaimsList = await userManager.GetClaimsAsync(user);
            //secret Key
            string SecretKey = configuration.GetValue<string>("SecretKey")!;
            var keyInBytes = Encoding.ASCII.GetBytes(SecretKey);
            var key = new SymmetricSecurityKey(keyInBytes);
            //hashing algorithm
            var algorithm = SecurityAlgorithms.HmacSha256Signature;
            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                claims: ClaimsList,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(10)
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            return new TokenDto
            {
                Token = tokenHandler.WriteToken(token)
            };

            #endregion

        }
        #region Register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,                
                //For Password Prperty we don't have password we do have HashPassword
            };
            //to create password we will use our _usermanager
            var CreationResult = await userManager.CreateAsync(user, registerDto.Password);
            if (!CreationResult.Succeeded)
            {
                return BadRequest(CreationResult.Errors);
            }
            var claimsList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Role,"Admin")
            };
            await userManager.AddClaimsAsync(user, claimsList);
            return NoContent();
        }
        #endregion

    }
}
//Login: AbdullahMamhmoud => Elhammar
