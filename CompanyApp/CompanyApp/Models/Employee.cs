using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyApp.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter your age")]
        [Range(18, 40, ErrorMessage = "Age must be between 18 to 40")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter number of years of experience")]
        [Display(Name = "Number of years of Experience")]
        public int ExperienceYears { get; set; }
        [Required(ErrorMessage = "Please enter your gender")]

        public string? Gender { get; set; }
    }
}
