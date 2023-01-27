using Exercise6.Models;

namespace Exercise6.Conf
{
    public class ApplicationContext
    {
        private List<Employee> employees;
        private List<SalesEmployee> salesEmployees;

        private static ApplicationContext instance = null;

        public static ApplicationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationContext();
                }
                return instance;
            }
        }

        public ApplicationContext()
        {
            this.employees = new List<Employee>();
        }
        public List<Employee> GetEmployees()
        {
            return this.employees;
        }

        public List<SalesEmployee> GetSalesEmployees()
        {
            return this.salesEmployees;
        }
    }
}