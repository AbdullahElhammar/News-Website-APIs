using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace NewsSystem.DAL;

public class SystemContext: IdentityDbContext<User>
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<News> News => Set<News>();
    public DbSet<Image> Images => Set<Image>();
    public SystemContext(DbContextOptions<SystemContext> options) : base(options) { }


    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    #region AuthorsList
    //    var Authors = new List<Author>
    //        {
    //            new Author { Id = 1,Name="ahmed"},
    //            new Author { Id = 2,Name="abdullah"},
    //            new Author { Id = 3,Name="omar"},
    //            new Author { Id = 4,Name="othman"}
    //        };
    //    #endregion
    //    #region NewsList
    //    var News = new List<News>
    //        {
    //            new News { Id = 1,Title="ahmednews", Description="ioefhwohwjdoicjwdo"},
    //            new News { Id = 2,Title="abdullahnews",Description= "poriwproweupiioefhwohwjdoicjwdo"},
    //            new News { Id = 3,Title="omarnews",Description= ";liofoiodioefhwohwjdoicjwdo"},
    //            new News { Id = 4,Title="othmannews",Description="popioiioefhwohwjdoicjwdo"}
    //        };
    //    #endregion
    //    #region Images
    //    var ImageList = new List<Image>
    //    {
    //        new Image{Id=1,ImgUrl="img1.jpg",NewsId=1 },
    //        new Image{Id=2,ImgUrl="img2.jpg",NewsId=1 },
    //        new Image{Id=3,ImgUrl="img3.jpg",NewsId=1 },
    //        new Image{Id=4,ImgUrl="img4.jpg",NewsId=2 },
    //        new Image{Id=5,ImgUrl="img5.jpg",NewsId=2 },
    //        new Image{Id=6,ImgUrl="img6.jpg",NewsId=2 },
    //        new Image{Id=7,ImgUrl="img7.jpg",NewsId=3 },
    //        new Image{Id=8,ImgUrl="img8.jpg",NewsId=3 },
    //        new Image{Id=9,ImgUrl="img9.jpg",NewsId=3 },
    //        new Image{Id=10,ImgUrl="img10.jpg",NewsId=4 },
    //        new Image{Id=11,ImgUrl="img11.jpg",NewsId=4 },
    //    };
    //    #endregion
    //    builder.Entity<Author>().HasData(Authors);
    //    builder.Entity<News>().HasData(News);
    //    builder.Entity<Image>().HasData(ImageList);
    //}

}
