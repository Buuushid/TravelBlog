using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelBlogDB1.Models;

namespace TravelBlogDB1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Email> Emails { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }
    }
}
