using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TpCRUDMVCScolariteSuivi.Models
{
    public class ScolariteDbEntities : IdentityDbContext
    {

        public ScolariteDbEntities(DbContextOptions<ScolariteDbEntities> opts) : base(opts)
        {

        }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Parcour> Parcours { get; set; }

    }
}
   