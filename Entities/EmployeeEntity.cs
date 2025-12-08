using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeListApp.Entities
{
    public class EmployeeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public required string FirstName { get; set; } 

        public required string LastName { get; set; }
        
        public required string Email { get; set; } 

        public required string Position { get; set; } 

        public DateTime DateHired { get; set; } 

        public decimal Salary { get; set; }
    }
}
