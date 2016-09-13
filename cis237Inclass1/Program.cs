using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237Inclass1
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee myEmployee = new Employee();

            myEmployee.FirstName = "Marty";
            myEmployee.LastName = "Russon";
            myEmployee.WeeklySalary = 2048.34m;

            Console.WriteLine(myEmployee.FirstName);
            Console.WriteLine(myEmployee);

            Employee[] employees = new Employee[12];

            employees[0] = new Employee("James", "Kirk", 453.00m);
            employees[1] = new Employee("Jen-Luc", "Picard", 453.00m);
            employees[2] = new Employee("Benjamin", "Sisko", 453.00m);
            employees[3] = new Employee("Katheryn", "Janeway", 1253.00m);
            employees[4] = new Employee("Jonathon", "Archer", 953.00m);
            employees[5] = new Employee("Bob", "Kirk", 253.00m);
            employees[6] = new Employee("Bill", "Kirk", 353.00m);
            employees[7] = new Employee("Steve", "Kirk", 553.00m);
            employees[8] = new Employee("Maggy", "Kirk", 653.00m);
            employees[9] = new Employee("Wilbur", "Kirk", 753.00m);


            foreach (Employee employee in employees)
            {
                if (employee != null)
                { 
                Console.WriteLine(employee.ToString() + " " + employee.YearlySalary());
                }
            }


            UserInterface ui = new UserInterface();


            int choice = ui.GetUserInput();

            while (choice != 2)
            { 
                if (choice == 1) //May be better to use a switch statement
                {
                    string allOutput = "";
                    foreach (Employee employee in employees)
                    {
                        if (employee != null)
                        {
                            allOutput += employee.ToString() + " " + employee.YearlySalary() + Environment.NewLine;
                        }
                    }

                    ui.PrintAllOutput(allOutput);
                

                }
                choice = ui.GetUserInput();
            }



        }
    }
}
