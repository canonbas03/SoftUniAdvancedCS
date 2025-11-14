using P03.Detail_Printer;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();

            var employee = new Employee("Josh");
            employees.Add(employee);
            var manager = new Manager("Mike", new List<string>() { "test", "test2.pdf"});
            employees.Add(manager);
            var ceo = new CEO("Miranda", new List<string>() { "test.docs", "test2.xml" },"Wealthy");
            employees.Add(ceo);

            var printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}
