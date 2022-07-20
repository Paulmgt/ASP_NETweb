namespace TpCRUDMVCScolariteSuivi.Models
{
    public class Module
    {
        int Id { get; set; }

        string Nom { get; set; }

        string Logo { get; set; }

        string Resume { get; set; }

        string info { get; set; }

        public ICollection<Parcour>? Parcour { get; set; } = new List<Parcour>();
    }
}
