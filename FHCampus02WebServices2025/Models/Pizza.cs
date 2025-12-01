using System.ComponentModel.DataAnnotations;

namespace FHCampus02WebServices2025.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Der Name der Pizza ist erforderlich.")]
        [MaxLength(100, ErrorMessage = "Der Name darf maximal 100 Zeichen lang sein.")]
        public string? Name { get; set; }

        public bool IsGlutenFree { get; set; }

        // Wichtig: Property, nicht Feld + Range-Validierung
        [Range(0, double.MaxValue, ErrorMessage = "Kalorien dürfen nicht negativ sein.")]
        public double Kalorien { get; set; }
    }
}
