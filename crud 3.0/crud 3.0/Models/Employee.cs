using System.ComponentModel.DataAnnotations;

namespace crud_3._0.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="Please enter name before submit")]
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Salary { get; set; }

    }
}
