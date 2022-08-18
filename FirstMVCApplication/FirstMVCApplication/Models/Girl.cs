using System.ComponentModel.DataAnnotations;
namespace FirstMVCApplication.Models
{
    public class Girl
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
