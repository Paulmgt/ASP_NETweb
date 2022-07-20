namespace WebAppTp2.Models
{
    public class Marque
    {

        public int Id { get; set; }

        public string Nom { get; set; }

        // Props de Navigation
        // Pour une Marque ==> Liste de Voitures


        public ICollection<Voiture>? Voitures { get; set; } = new List<Voiture>();
    }
}
