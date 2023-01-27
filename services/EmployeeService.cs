using Exercise6.Interfaces;
using Exercise6.Models;
using Exercise6.Conf;

namespace Exercise6.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationContext appInstance;
        private List<Employee> employees;
        private List<SalesEmployee> salesEmployees;

        public EmployeeService()
        {
            appInstance = ApplicationContext.Instance;
            employees = appInstance.GetEmployees();
            salesEmployees = appInstance.GetSalesEmployees();
        }

        public void AddSale(Employee e, Sale s)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee e)
        {
            Employee empToDelete = employees.SingleOrDefault(x => x == e);
            employees.Remove(empToDelete);
        }

        public List<Employee> GetAll()
        {
            return this.employees;
        }

        public List<SalesEmployee> GetAllSalesEmployees()
        {
            return this.salesEmployees;
        }

        public Employee Save(Employee e)
        {
            employees.Add(e);
            return e;
        }

        public Employee FindById(int id)
        {
            Employee emp = employees.SingleOrDefault(x => x.Id == id);
            return emp;
        }
    }
}