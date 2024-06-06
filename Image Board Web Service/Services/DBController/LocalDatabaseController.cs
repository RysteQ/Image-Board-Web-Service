using Image_Board_Web_Service.Models.OrmModels;
using Microsoft.EntityFrameworkCore;

namespace Image_Board_Web_Service.Services.DBController;

public class LocalDatabaseController : DbContext
{
    public LocalDatabaseController()
    {
        DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _databaseName);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
    }

    public DbSet<ImageOrm> Images { get; set; }
    public DbSet<ImageRatingOrm> Ratings { get; set; }
    public DbSet<ImageCommentOrm> Comments { get; set; }

    private string DatabasePath { get; init; }
    private const string _databaseName = "local_database.db";
}