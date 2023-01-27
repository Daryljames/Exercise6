namespace Exercise6.Models
{
    public class Employee : Person
    {
        public string EmployeeNumber { get; set; }
        public float BaseSalary { get; set; }

        public Employee(int id, string firstName, string lastname, string employeeNumber, float baseSalary) : base(id, firstName, lastname)
        {
            EmployeeNumber = employeeNumber;
            BaseSalary = baseSalary;
        }

        public float GetSalary()
        {
            return this.BaseSalary;
        }
    }
}