/*
  Create an interface called IEmployeeService with the following methods:
List<Employee> GetAll()
List<Employee> GetAllSalesEmployees()
Employee Save(Employee e)
void Delete(Employee e)
AddSale(SalesEmployee e, Sale s)
*/

using Exercise6.Models;

namespace Exercise6.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetAll();

        public List<SalesEmployee> GetAllSalesEmployees();

        public Employee Save(Employee e);

        public void Delete(Employee e);

        public void AddSale(Employee e, Sale s);

        public Employee FindById(int id);

        public SalesEmployee FindSalesEmpById(int id);

    }
}