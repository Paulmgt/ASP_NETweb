namespace TpCRUDMVCScolariteSuivi.Models
{
    public class Module
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string? Logo { get; set; }

        public string? Resume { get; set; }

        public string? info { get; set; }

        public ICollection<Parcour>? Parcour { get; set; } = new List<Parcour>();
    }
}
