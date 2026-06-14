using System;
using System.Collections.Generic;


abstract class Employee
{
    public int EmployeeId;
    public string EmployeeName;
    protected double Salary;

    public Employee(int id, string name, double salary)
    {
        EmployeeId = id;
        EmployeeName = name;
        Salary = salary;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Employee: " + EmployeeName);
    }

    public abstract void CalculateSalary();
}


class PermanentEmployee : Employee
{
    public PermanentEmployee(int id, string name, double salary)
        : base(id, name, salary)
    {
    }

    public override void CalculateSalary()
    {
        Console.WriteLine("Type: Permanent");
        Console.WriteLine("Salary: " + Salary);
    }
}


class ContractEmployee : Employee
{
    public ContractEmployee(int id, string name, double salary)
        : base(id, name, salary)
    {
    }

    public override void CalculateSalary()
    {
        Console.WriteLine("Type: Contract");
        Console.WriteLine("Salary: " + Salary);
    }
}

class case4
{
    static void MainDisabled()
    {
        List<Employee> employees = new List<Employee>();

        employees.Add(new PermanentEmployee(1, "Krishna", 75000));
        employees.Add(new ContractEmployee(2, "Ravi", 45000));

        foreach (Employee e in employees)
        {
            e.DisplayInfo();
            e.CalculateSalary();
            Console.WriteLine();
        }
    }
}