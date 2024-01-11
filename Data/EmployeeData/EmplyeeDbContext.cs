using System.Data;
using EmployeeEntityModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData;


public class EmplyeeDbContext:DbContext
{
    public EmplyeeDbContext(DbContextOptions<EmplyeeDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<EmployeeDetails> EmployeeDetails{get; set;}
}
