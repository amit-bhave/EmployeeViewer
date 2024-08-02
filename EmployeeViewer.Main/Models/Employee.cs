namespace EmployeeViewer.Main.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }

        public double Salary { get; set; }
    }
}
