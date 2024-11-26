using HRAdministrationAPI;

decimal totalSalaries = 0;
List<IEmployee> employees = new List<IEmployee>();

SeedData(employees);

foreach (IEmployee employee in employees)
{
    totalSalaries += employee.Salary;
}

Console.WriteLine($"Total Annual Salaries(Including bonuses): {totalSalaries}");
static void SeedData(List<IEmployee> employees)
{
    IEmployee teacher1 = new Teacher()
    {
        FirstName = "Teacher",
        LastName = "Teacher",
        Id = 1,
        Salary = 20000
    };
    employees.Add(teacher1);
    IEmployee teacher2 = new Teacher()
    {
        FirstName = "Jack",
        LastName = "Matubia",
        Id = 2,
        Salary = 50000
    };
    employees.Add(teacher2);
    IEmployee headMaster = new HeadMaster()
    {
        FirstName = "John",
        LastName = "Doe",
        Id = 3,
        Salary = 25000
    };
    employees.Add(headMaster);
    IEmployee headOfDepartment = new HeadOfDepartment()
    {
        FirstName = "Jane",
        LastName = "Dew",
        Id = 4,
        Salary = 40000
    };
    employees.Add(headOfDepartment);
    IEmployee deputyHeadMaster = new DeputyHeadMaster()
    {
        FirstName = "Peter",
        LastName = "Kamau",
        Id = 5,
        Salary = 30000
    };
    employees.Add(deputyHeadMaster);
}
public class Teacher : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
}

public class HeadOfDepartment : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }

}

public class DeputyHeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }

}

public class HeadMaster : EmployeeBase
{
    public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }

}