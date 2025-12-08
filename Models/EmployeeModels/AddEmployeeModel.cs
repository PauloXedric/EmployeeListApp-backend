using System.ComponentModel.DataAnnotations;

namespace EmployeeListApp.Models.EmployeeModels
{
    public class AddEmployeeModel
    {
        [Required]
        [MaxLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Position { get; set; }

        public DateTime DateHired { get; set; } = DateTime.Now;

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
