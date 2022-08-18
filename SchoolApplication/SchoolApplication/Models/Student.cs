using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApplication.Models
{
    public class Student
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Range(1, 12)]
        public int Class { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Rating { get; set; }
        //public Rating Rating { get; set; }
    }

    public enum Rating
    {
        [Description("Good")]
        Good,
        [Description("Excellent")]
        Excellent,
        [Description("Improvement")]
        Improvement,
        [Description("Bad")]
        Bad,
        [Description("Worst")]
        Worst
    }
}


