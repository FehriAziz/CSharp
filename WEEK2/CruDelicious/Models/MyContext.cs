#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace CruDelicious.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) {}
    // Add All Tables Here
    //- access modifier type DbSet<Model> table name getter setter
    public DbSet<Dish> Dishs { get; set; }
}