using System;
using System.Collections.Generic;

public class University
{
    public University()
    {
        Departments = new List<Department>();
    }

    public string Name { get; set; }

    public List<Department> Departments { get; set; }

    public void PrintStructure()
    {
        Console.WriteLine(Name);

        foreach (Department dept in Departments)
        {
            Console.WriteLine($"- {dept.Name}");

            foreach (Employee emp in dept.Employees)
            {
                Console.WriteLine($"-- {emp.FullName} - {emp.Position}");
            }

            if (dept.SubDepartments.Count > 0)
            {
                foreach (Department subDept in dept.SubDepartments)
                {
                    Console.WriteLine($"--- {subDept.Name}");
                }
            }
        }
    }
}

public class Department
{
    public Department()
    {
        Employees = new List<Employee>();
        SubDepartments = new List<Department>();
    }

    public string Name { get; set; }

    public List<Employee> Employees { get; set; }

    public List<Department> SubDepartments { get; set; }
}

public class Employee
{
    public string FullName { get; set; }

    public string Position { get; set; }
}


class Program
{
    static void Main(string[] args)
    {
        //...

        University university = new University();
        university.Name = "Київський національний університет";

        // Додаємо структуру КНУ

        University university2 = new University();
        university2.Name = "Харківський національний університет";

        Department historyDepartment = new Department();
        historyDepartment.Name = "Історичний факультет";

        Employee petrenko = new Employee();
        petrenko.FullName = "Сергій Петренко";
        petrenko.Position = "Доцент";

        historyDepartment.Employees.Add(petrenko);

        university2.Departments.Add(historyDepartment);

        // Виводимо структуру ХНУ
        university2.PrintStructure();

        Console.ReadLine();
    }
}