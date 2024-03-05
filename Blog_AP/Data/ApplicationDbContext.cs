using Blog_AP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog_AP.Data
{
    public class ApplicationDbContext : IdentityDbContext
	{
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Blog_AP.Models.User>? User { get; set; }
        public DbSet<Blog_AP.Models.Role>? Role { get; set; }
        public DbSet<Blog_AP.Models.Article>? Article { get; set; }
        public DbSet<Blog_AP.Models.Faculty>? Faculty { get; set; }
    }
}
