namespace Exercise6.Models
{
    public class SalesEmployee : Employee
    {
        public float Commission { get; set; }
        public List<Sale> Sales { get; set; }

        public SalesEmployee(int id, string firstName, string lastname, string employeeNumber, float baseSalary, float commission) : base(id, firstName, lastname, employeeNumber, baseSalary)
        {
            this.Commission = commission;
            Sales = new List<Sale>();
        }

        public float GetSalary()
        {
            float totalSales = 0;
            foreach (Sale s in Sales)
            {
                totalSales += s.Amount;
            }
            return BaseSalary + Commission * totalSales;
        }
    }
}