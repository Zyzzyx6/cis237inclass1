using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cis237Inclass1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring a variable of type Employee (which is a class) and
            //instanciating a new instance of Employee and assigning it to
            //a variable using the NEW keywordd means that the memory will get allocate on the Heap
            //for that class
            Employee myEmployee = new Employee();

            //use the properties to assign values
            myEmployee.FirstName = "Marty";
            myEmployee.LastName = "Russon";
            myEmployee.WeeklySalary = 2048.34m;

            //Output the first name of the employee using the property.
            Console.WriteLine(myEmployee.FirstName);

            //Output the entire employee which will call the ToString method implicitly.
            //This would work even without overriding the ToString method in the Employee class.
            //however it would only spit out the namespace and name of the class instead of something useful.
            Console.WriteLine(myEmployee);

            //Creat an array of type Employee to hold a bunch of Employees
            Employee[] employees = new Employee[12];

            //Assign values to the array. Each spot needs to contain an instance of an Employee
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

            //A foreach loop. It is useful for doing a collection of objects.
            //Each object in the array'employees' will get assigned to the local
            //variable 'employee' inside the loop.
            foreach (Employee employee in employees)
            {
                //Run a check to make sure the spot in the array is not empty
                if (employee != null)
                { 
                    //print the employee
                Console.WriteLine(employee.ToString() + " " + employee.YearlySalary());
                }
            }


            //Use the CSVProcessor method that we wrote into main to load the
            //employees from the csv file
            ImportCSV("employees.csv", employees);
            //ImportCSV("../../employees.csv", employees); Relative path to csv file

            //Instanciate a new UI class
            UserInterface ui = new UserInterface();


            //Get the user input from the ui class
            //int choice = ui.GetUserInput();

            //Could use the instance one above but to demonstrate using a static
            //class we are calling the static version
            //If you hate static classes and want to avoid them feel free
            //to comment the below line and uncomment above line
            int choice = StaticUserInterface.GetUserInput();


            //While the choice that they entered is not 2, we will loop to
            //continue to get the next choice of what they want to do.
            while (choice != 2)
            { 
                //if the choice they made is 1, (which for us is the only choice)
                if (choice == 1) //May be better to use a switch statement
                {
                    //Create a string to concat the output
                    string allOutput = "";

                    //Loop through the employees just like above only instead of
                    //writing out the employees, we are concating them together
                    foreach (Employee employee in employees)
                    {
                        if (employee != null)
                        {
                            allOutput += employee.ToString() + " " + employee.YearlySalary() + Environment.NewLine;
                        }
                    }
                    //Once the concat is done, have the UI class print out the result
                    ui.PrintAllOutput(allOutput);
                

                }
                //Get the next choice from user
                choice = ui.GetUserInput();
            }

        }

        static bool ImportCSV(string pathToCsvFile, Employee[] employees)  //dependancy injection
        {
            //Declare a variable for the streamreader. Not going to instantiate it yet.
            StreamReader streamReader = null;

            //Strat a try since the path to the file could be incorrect, and thus
            //throw an exception.
            try
            {
                //Declare a string for each line we will read in
                string line;

                //Instantiate the streamreader. If the path to the file is cincorrect it will
                //throw an exception that we can catch
                streamReader = new StreamReader(pathToCsvFile);

                //Set up a counter that we arent using yet
                int counter = 0;

                //While there is a line to read, read the line and put it into the line var
                while ((line = streamReader.ReadLine()) != null)
                {
                    //Call the process line method and send over the read in line.
                    //the employees array (which is passed by reference automatically),
                    //and the counter, which will be used as the index for the array.
                    //We are also incrementing the counter after we send it in with the ++ operator.
                    processLine(line, employees, counter++);

                }
                //All the Reads are successful, return true
                return true;
            }
            catch (Exception e)
            {
                //output the exception string, and the stack trace.
                //The stack trace is all of the method callls that lead to
                //where the exception occured
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);

                //Return false, reading failed
                return false;
            }
            //Used to ensure the code within it gets executed regardless of whether the
            //try succeeds or the catch gets executed.
            finally
            {
                //Check to make sure that the StreamReader is actually instanciated before
                //trying to  call a method on it
                if (streamReader != null)
                {
                    //Close the streamReader
                    streamReader.Close();
                }
            }

          
            


        }
        static void processLine(string line, Employee[] employees, int index)
        {
            //declare a string array and assign the split line to it
            string[] parts = line.Split(',');

            //Assign the parts to local variables that mean something
            string firstName = parts[0];
            string lastName = parts[1];
            decimal salary = decimal.Parse(parts[2]);

            //Use the variables to instantiate a new Employee and assign it to
            //the spot in the employees array indexed by the index that was passed in.
            employees[index] = new Employee(firstName, lastName, salary);


        }


    }
}
