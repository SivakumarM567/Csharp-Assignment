using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Csharp_Assignment
{
    class Program
    {
        class Employee
        {
            public int EmpNo;
            public string EmpName;
            public double Salary;
            public double HRA;
            public double TA;
            public double DA;
            public double PF;
            public double TDS;
            public double NetSalary;
            public double GrossSalary;

            public void setDataEmployee(int EmpNo, string EmpName, double Salary, double HRA, double TA, double DA)
            {
                this.EmpNo = EmpNo;
                this.EmpName = EmpName;
                this.Salary = Salary;
                this.HRA = HRA;
                this.TA = TA;
                this.DA = DA;

                this.GrossSalary = calculateGrossSalary();
                this.PF = calculatePF();
                this.TDS = calculateTDS();
                this.NetSalary = calculateNetSalary();
            }
            public double calculateGrossSalary()
            {
                return Salary + Salary * HRA / 100.0 + Salary * TA / 100.0 + Salary * DA / 100.0;
            }
            public double calculatePF()
            {
                return 0.1 * GrossSalary;
            }
            public double calculateTDS()
            {
                return 0.18 * GrossSalary;
            }
            public double calculateNetSalary()
            {
                return GrossSalary - (PF + TDS );
            }
        }

        class Library
        {
            private List<Employee> employees = new List<Employee>();


            public void addEmployee(Employee emp)
            {
                this.employees.Add(emp);
            }


            public void displayEmployees()
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    Console.WriteLine("EmpNo: {0}", employees[i].EmpNo);
                    Console.WriteLine("EmpName: {0}", employees[i].EmpName);
                    Console.WriteLine("Salary: {0}", employees[i].Salary);
                    Console.WriteLine("HRA: {0}", employees[i].HRA);
                    Console.WriteLine("TA: {0}", employees[i].TA);
                    Console.WriteLine("DA: {0}", employees[i].DA);
                    Console.WriteLine("PF: {0}", employees[i].PF);
                    Console.WriteLine("TDS: {0}", employees[i].TDS);
                    Console.WriteLine("Net Salary: {0}", employees[i].NetSalary);
                    Console.WriteLine("Gross Salary: {0}", employees[i].GrossSalary);
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            Library library = new Library();
            int ch = -1;
            do
            {
                Console.WriteLine("Welcome to Litware");
                Console.WriteLine("1. Register the employee");
                Console.WriteLine("2. Display employee");
                Console.WriteLine("3. Exit\n");
                Console.Write("Your choice: ");
                ch = int.Parse(Console.ReadLine());
                if (ch == 1)
                {
                    Console.Write("Enter EmpNo: ");
                    int EmpNo = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter EmpName: ");
                    string EmpName = Console.ReadLine();
                    Console.Write("Enter Employee Salary: ");
                    double Salary = double.Parse(Console.ReadLine());
                    Console.Write("Enter Employee HRA : ");
                    double HRA = double.Parse(Console.ReadLine());
                    Console.Write("Enter Employee TA  : ");
                    double TA = double.Parse(Console.ReadLine());
                    Console.Write("Enter Employee DA  : ");
                    double DA = double.Parse(Console.ReadLine());
                    Employee emp = new Employee();
                    emp.setDataEmployee(EmpNo, EmpName, Salary, HRA, TA, DA);
                    library.addEmployee(emp);
                }
                else if (ch == 2)
                {
                    library.displayEmployees();
                }
            } while (ch != 3);

            Console.ReadKey();
        }
    }
}