using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppTp2.Models
{
    public class VoitureDbEntities : IdentityDbContext
    {

        public VoitureDbEntities(DbContextOptions<VoitureDbEntities> opts) : base(opts)
        {

        }

        public DbSet<Voiture> Voitures { get; set; }

        public DbSet<Marque> Marques { get; set; }

    }
}
