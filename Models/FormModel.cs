using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TPLOCAL1.Models
{   // Données saisies dans le formulaire avec les contrôles
    public class FormModel
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Veuillez sélectionner un sexe")]
        public string Genre { get; set; } = "";

        [Required(ErrorMessage = "L'adresse est obligatoire")]
        public string Address { get; set; } = "";

        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit contenir 5 chiffres")]
        [Required(ErrorMessage = "Le code postal est obligatoire")]
        public string PostalCode { get; set; } = "";

        [Required(ErrorMessage = "La ville est obligatoire")]
        public string City { get; set; } = "";

        [RegularExpression(@"^([\w.]+)@([\w]+)\.([\w]+)$", ErrorMessage = "Format attendu: nom@domaine.fr")]
        [Required(ErrorMessage = "L'email est obligatoire")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "La date est obligatoire")]
        public DateTime? StartDate { get; set; }
        //le "?" autorise une date vide
        [Required(ErrorMessage = "Veuillez sélectionner une formation")]
        public string CoursesType { get; set; } = "";

        // Avis facultatif
        public string? CobolFormation { get; set; } = "";
        // Avis facultatif
        public string? CSharpFormation { get; set; } = "";
    }
}
