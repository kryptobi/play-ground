namespace OneOfExample;

public class Employer
{
    public Employer(string companyName, string address)
    {
        CompanyName = companyName;
        Address = address;
    }

    public string CompanyName { get; set; }
    public string Address { get; set; }
}