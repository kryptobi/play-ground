namespace OneOfExample;

public class Employee
{
    public Employee(string username, double salary)
    {
        Username = username;
        Salary = salary;
    }

    public string Username { get; set; }
    public double Salary { get; set; }
}