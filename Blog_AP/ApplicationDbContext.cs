using Blog_AP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog_AP
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog_AP.Models.Role>? Role { get; set; }
        public DbSet<Blog_AP.Models.Post>? Post { get; set; }
        public DbSet<Blog_AP.Models.Falcuty>? Falcuty { get; set; }
    }
}
