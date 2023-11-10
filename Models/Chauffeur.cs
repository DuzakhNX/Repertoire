using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class Chauffeur
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        [Display(Name = "Numero du Camion")]
        public string? Numero_Camion { get; set; }
        [Display(Name = "Téléphone du Togo")]
        public string? Tel_Togo { get; set; }
        [Display(Name = "Téléphone du Bénin")]
        public string? Tel_Benin { get; set; }
        [Display(Name = "Téléphone du Niger")]
        public string? Tel_Niger { get; set; }
        [Display(Name = "Pays du Camion")]
        public string? Genre_Camion { get; set; }
        public string? Proprietaire { get; set; }
        [Display(Name = "Téléphone du Propriétaire")]
        public string? Numero_Proprietaire { get; set; }
    }
}
