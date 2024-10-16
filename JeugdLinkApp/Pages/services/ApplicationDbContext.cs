using JeugdLinkApp.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace JeugdLinkApp.Pages.services
{
    public class ApplicationDbContext: DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }

    
}
