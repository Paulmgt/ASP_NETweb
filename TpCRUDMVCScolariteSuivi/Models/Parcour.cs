namespace TpCRUDMVCScolariteSuivi.Models
{
    public class Parcour
    {
     public  int Id { get; set; }

     public string Nom { get; set; }
    
     public string? Logo { get; set; }

     public string? Resume { get; set; }

     public string? Infos { get; set; } 

     public int ModuleId { get; set; }

     public Module? Module { get; set; }
    }
}
