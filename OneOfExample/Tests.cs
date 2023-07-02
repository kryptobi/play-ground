using FluentAssertions;
using OneOf;
using Xunit;
 
namespace OneOfExample;

public class Tests
{
    private OneOf<Employer, Employee> GetIt(bool isBoss)
    {
        if (isBoss)
        {
            return new Employer("traperto", "Gertrud-Boss-Straße 7");
        }

        return new Employee("Schuhmacher", 13.37);
    }

    [Fact]
    public void ItShouldWork()
    {
        var anyThing = GetIt(false);
        anyThing.Value.Should().BeAssignableTo(typeof(Employee));
        
        var anyThing1 = GetIt(true);
        anyThing.Value.Should().BeAssignableTo(typeof(Employer));
    }
}