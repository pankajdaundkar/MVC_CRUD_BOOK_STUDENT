using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Percentage { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [ScaffoldColumn(false)]
        public int isActive { get; set; }

    }
}
