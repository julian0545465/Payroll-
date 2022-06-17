
using Newtonsoft.Json;

namespace Payroll
{
    internal class Counts
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("WELCOME TO THE PROGRAM");
            int Opc1 = 1;
            int numberEmployee = 1;
            List<Employee> employees = new List<Employee>();
            do
            {
                Console.WriteLine($"--------------------  EMPLOYEE {numberEmployee}  --------------------");
                Console.WriteLine("1. Press one if you want to add other employee");
                Console.WriteLine("2. Press two if you want to exit");
                Opc1 = int.Parse(Console.ReadLine());
                switch (Opc1)
                {
                    case 1:

                        Employee employee = new Employee();
                        ReadEmployee(employee);
                        CalculateValues(employee);
                        PrintDataEmployee(employee);
                        employees.Add(employee);
                        SaveToFile(employees);
 
                        break;
                    case 2:
                        Console.WriteLine("");
                        Console.WriteLine("Leaving the program");
                        break;
                    default:
                        Console.WriteLine("The option not is valid, plis insert other value ");
                        break;

                }
                Console.ReadKey();

                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Clear();
                numberEmployee++;
            } while (Opc1 != 2);
        }

        public static Employee ReadEmployee(Employee employee)
        {
            try
            {
                Console.WriteLine("Insert the document of the employee");
                employee.DocumentId = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Insert the Name of the employee");
                employee.Name = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Insert the Last Name of the employee");
                employee.LastName = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Insert the salary of the employee");
                employee.Salary = double.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.WriteLine("Insert the days worked of the employee");
                employee.WorkedDays = double.Parse(Console.ReadLine());
                Console.WriteLine("");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("El value no is valid.\nInsert other number value", ex);
                Console.ReadKey();
            }

            return employee;
        }

        public static Employee CalculateValues(Employee employee)
        {
            int Days = 30;
            int PriceAuxTransport = 117_172;
            int ConditionSalary = 2_000_000;
            double Percentage = 0.04;

            employee.TotalAccrued = employee.Salary / Days;
            employee.TotalAccrued = employee.TotalAccrued * employee.WorkedDays;

            employee.AuxTransport = PriceAuxTransport / Days;
            employee.AuxTransport = employee.AuxTransport * employee.WorkedDays;

            employee.Health = employee.TotalAccrued * Percentage;
            employee.Pension = employee.TotalAccrued * Percentage;

            if (employee.Salary <= ConditionSalary)
            {
                employee.TotalAccrued = employee.TotalAccrued + employee.AuxTransport;
            }
            else
            {
                employee.TotalAccrued = employee.TotalAccrued;
            }

            return employee;
        }

        public static Employee PrintDataEmployee(Employee employee)
        {
            Console.WriteLine($"Document:{employee.DocumentId} ");
            Console.WriteLine($"Name: {employee.Name}");
            Console.WriteLine($"Last Name: {employee.LastName}");
            Console.WriteLine($"Salary: {employee.Salary}");
            Console.WriteLine($"Worked Days: {employee.WorkedDays}");
            Console.WriteLine($"Total Accrued: {employee.TotalAccrued}");
            Console.WriteLine($"Health: {employee.Health}");
            Console.WriteLine($"Pension: {employee.Pension}");
            return employee;
        }

        public static void SaveToFile(List<Employee> employees)
        {
            string FileName = "C:\\Employee.txt";
            try
            {
                string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
                File.WriteAllText(FileName, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("Error to save the program", ex);
            }
        }
    }
}
