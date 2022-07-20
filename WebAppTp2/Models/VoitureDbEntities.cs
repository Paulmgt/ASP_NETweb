using Microsoft.EntityFrameworkCore;

namespace WebAppTp2.Models
{
    public class VoitureDbEntities : DbContext
    {

        public VoitureDbEntities(DbContextOptions<VoitureDbEntities> opts) : base(opts)
        {

        }

        public DbSet<Voiture> Voitures { get; set; }

        public DbSet<Marque> Marques { get; set; }

    }
}
