using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarShopMax.Model;

public class CarShopMaxContext : DbContext
{

    /// <summary>
    /// Database path
    /// </summary>
    public string DbPath { get; }

    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }

    /// <summary>
    /// Default c-tor
    /// </summary>
    public CarShopMaxContext()
    {
        var currentLocation = Assembly.GetExecutingAssembly();
        var path = Path.GetDirectoryName(currentLocation.Location);
        DbPath = Path.Join(path, "Data.db");
    }

    /// <summary>
    /// On configuring override
    /// </summary>
    /// <param name="options"></param>
    protected override async void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }

}