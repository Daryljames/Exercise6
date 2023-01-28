using Exercise6.Models;
using Exercise6.Services;
using Exercise6.Interfaces;

namespace Exercise6
{
    public class Program
    {
        public static IEmployeeService employeeService = new EmployeeService();
        public static void Main(string[] args)
        {
            /*
Create an interface that implements at least the following:
Listing all employees (first all normal employees then sales employees)\
Save an Employee record
Delete an Employee
Add a sale to a selected sales employee

Program should be able to loop until user enters the option “quit”


            */

            List<Employee> employeesList = employeeService.GetAll();
            bool displayMenu = true;

            while (displayMenu)
            {
                Console.WriteLine("Welcome to Employee Management System");
                Console.WriteLine("Select from the following options:");
                Console.WriteLine("1 - List all Employees");
                Console.WriteLine("2 - Save an Employee Record");
                Console.WriteLine("3 - Delete an Employee");
                Console.WriteLine("4 - Add a Sale to a Selected Sales Employee");
                Console.WriteLine("5 - Quit");
                System.Console.Write("Enter Number: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                bool selection = true;

                while (selection)
                {
                    if (choice == 1)
                    {
                        if (employeesList.Count() > 0)
                        {
                            System.Console.WriteLine("Here are your employee list");
                            for (int i = 0; i < employeesList.Count(); i++)
                            {
                                Employee emp = employeesList[i];
                                if (emp.GetType() == typeof(Employee))
                                {
                                    Employee temp = (Employee)emp;
                                    System.Console.Write("Employee: ");
                                    System.Console.WriteLine(temp.Id + " - " + temp.FirstName + " " + temp.LastName);
                                }
                                else if (emp.GetType() == typeof(SalesEmployee))
                                {
                                    SalesEmployee temp = (SalesEmployee)emp;
                                    System.Console.Write("Sales Employee: ");
                                    System.Console.WriteLine(temp.Id + " - " + temp.FirstName + " " + temp.LastName);
                                }
                            }
                            selection = false;
                        }
                        else
                        {
                            System.Console.WriteLine("List is currently empty");
                            System.Console.WriteLine("Going back to main menu");
                            selection = false;

                        }
                    }
                    else if (choice == 2)
                    {
                        System.Console.WriteLine("Are you adding an Employee or Sales Employee?");
                        bool displayAddMenu = true;
                        while (displayAddMenu)
                        {
                            System.Console.WriteLine("1 - Employee");
                            System.Console.WriteLine("2 - Sales Employee");
                            System.Console.WriteLine("3 - Go Back");
                            System.Console.Write("Enter Number: ");
                            int empChoice = int.Parse(Console.ReadLine());

                            bool selectionAddMenu = true;

                            while (selectionAddMenu)
                            {
                                if (empChoice == 1)
                                {
                                    System.Console.WriteLine("Enter first name");
                                    string firstName = Console.ReadLine();

                                    System.Console.WriteLine("Enter last name");
                                    string lastName = Console.ReadLine();

                                    System.Console.WriteLine("Enter employee number name");
                                    string employeeNumber = Console.ReadLine();

                                    System.Console.WriteLine("Enter base salary name");
                                    float baseSalary = float.Parse(Console.ReadLine());

                                    int id = employeesList.Count() + 1;
                                    Employee emp = new Employee(id, firstName, lastName, employeeNumber, baseSalary);

                                    emp = employeeService.Save(emp);
                                    System.Console.WriteLine("Employee " + emp.FirstName + " " + emp.LastName + " added");
                                    selectionAddMenu = false;

                                }
                                else if (empChoice == 2)
                                {
                                    System.Console.WriteLine("Enter first name");
                                    string firstName = Console.ReadLine();

                                    System.Console.WriteLine("Enter last name");
                                    string lastName = Console.ReadLine();

                                    System.Console.WriteLine("Enter employee number");
                                    string employeeNumber = Console.ReadLine();

                                    System.Console.WriteLine("Enter base salary");
                                    float baseSalary = float.Parse(Console.ReadLine());

                                    System.Console.WriteLine("Enter commission");
                                    float commission = float.Parse(Console.ReadLine());

                                    int id = employeesList.Count() + 1;
                                    SalesEmployee emp = new SalesEmployee(id, firstName, lastName, employeeNumber, baseSalary, commission);

                                    emp = (SalesEmployee)employeeService.Save(emp);
                                    System.Console.WriteLine("Sales Employee " + emp.FirstName + " " + emp.LastName + " added");
                                    selectionAddMenu = false;
                                }
                                else if (empChoice == 3)
                                {
                                    System.Console.WriteLine("Going back to main menu");
                                    selectionAddMenu = false;
                                    selection = false;
                                    displayAddMenu = false;
                                }
                                else
                                {
                                    System.Console.WriteLine("Please enter only one from the above numbers");
                                    selectionAddMenu = false;
                                    // displayAddMenu = false;
                                }
                            }
                        }

                    }
                    else if (choice == 3)
                    {
                        System.Console.WriteLine("Who would you like to delete?");
                        System.Console.Write("Enter ID:");
                        int id = int.Parse(Console.ReadLine());

                        Employee emp = employeeService.FindById(id);

                        if (emp != null)
                        {
                            employeeService.Delete(emp);
                            System.Console.WriteLine("Employee with ID " + emp.Id + " has been deleted");
                            selection = false;

                        }
                        else
                        {
                            System.Console.WriteLine("No Employee has that ID. Please try again");
                            selection = false;

                        }


                    }
                    else if (choice == 4)
                    {
                        System.Console.WriteLine("PLease Select a Sales Employee");
                        System.Console.Write("Enter ID of Sales Employee: ");

                        int id = int.Parse(Console.ReadLine());

                        Employee emp = employeeService.FindById(id);

                        if (emp != null)
                        {
                            System.Console.Write("Enter name of sale: ");
                            string nameSale = Console.ReadLine();
                            System.Console.Write("Enter amount of sale: ");
                            float amountSale = float.Parse(Console.ReadLine());

                            Sale sale = new Sale(nameSale, amountSale);

                            employeeService.AddSale(emp, sale);

                            selection = false;
                        }
                        else
                        {
                            System.Console.WriteLine("No Employee has that ID. Please try again");
                            selection = false;

                        }
                    }
                }
            }
        }
    }
}