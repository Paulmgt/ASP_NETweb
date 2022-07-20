namespace WebAppTp2.Models
{
    public class Voiture
    {

        public int Id { get; set; }

        public string Nom { get; set; }

        public string? Photo { get; set; }


        // Pour simplifier le codage au niveau du Front
        // On ajoute l'Id de la Marque ici

        public int MarqueId { get; set; }

        public Marque? Marque { get; set; }

        public string? Model { get; set; }

        public string? Chassis { get; set; }

        public string? Finition { get; set; }

        public string? NbPortes { get; set; }

        public string? Moteur { get; set; }

        public int? ChevauxDin { get; set; }

        public string? Couleur { get; set; }

       
        // Pour la vue 

        // => Photo de la Voiture

        // => Description de la Voiture

        // => ListBox pour choisir la marque

    }
}
