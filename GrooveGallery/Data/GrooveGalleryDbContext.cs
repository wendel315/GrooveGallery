using GrooveGallery.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GrooveGallery.Data
{
    public class GrooveGalleryDbContext : IdentityDbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string conn = config.GetConnectionString("Conn");

            optionsBuilder.UseSqlServer(conn);
        }
    }
}

