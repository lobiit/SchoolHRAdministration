using HRAdministrationAPI;
using SchoolHRAdministration;

decimal totalSalaries = 0;
List<IEmployee> employees = new List<IEmployee>();

SeedData(employees);

// foreach (IEmployee employee in employees)
// {
//     totalSalaries += employee.Salary;
// }

Console.WriteLine($"Total Annual Salaries(Including bonuses): {employees.Sum(emp => emp.Salary)}");
static void SeedData(List<IEmployee> employees)
{
    IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Teacher", "Kindiki", 20000);
    employees.Add(teacher1);
    IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Jack", "Matubia", 25000);

    employees.Add(teacher2);
    IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 3, "John", "Doe", 30000);
    employees.Add(headMaster);
    IEmployee headOfDepartment =EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 4, "Jane", "Dew", 40000);
    employees.Add(headOfDepartment);
    IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 5, "Peter", "Kamau", 50000);
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

public class EmployeeFactory
{
    public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName,
        decimal salary)
    {
        IEmployee employee = null;
        switch (employeeType)
        {
            case EmployeeType.Teacher:
                employee = FactoryPattern<IEmployee, Teacher>.GetInstance();  
                break;
            case EmployeeType.HeadOfDepartment:
                employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();  
                break;
            case EmployeeType.DeputyHeadMaster:
                employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();  
                break;
            case EmployeeType.HeadMaster:
                employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();  
                break;
            default:
                break;
        }

        if (employee != null)
        {
            employee.Id = id;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Salary = salary;
        }
        else
        {
            throw new NullReferenceException();
        }
        return employee;
    }
}