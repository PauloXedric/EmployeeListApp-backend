namespace EmployeeListApp.Models.EmployeeModels
{
    public class ReadEmployeeModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } =  string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public DateTime DateHired { get; set; }

        public decimal Salary { get; set; }
    }
}
