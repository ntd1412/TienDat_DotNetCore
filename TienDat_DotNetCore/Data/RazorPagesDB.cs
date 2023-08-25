using Microsoft.EntityFrameworkCore;
using TienDat_DotNetCore.Models.Domain;

namespace TienDat_DotNetCore.Data
{
    public class RazorPagesDB : DbContext
    {
        public RazorPagesDB(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
