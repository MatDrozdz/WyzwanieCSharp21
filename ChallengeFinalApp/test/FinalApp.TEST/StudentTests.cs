using Xunit;

namespace finalapp.test;

public class StudentMethodsTests
{
    [Fact]
    public void GetStatisticTest()
    {
        //arrange
        var student = new InMemoryStudent("Mateusz", "Drozdz");
        student.AddGrade(2.5);
        student.AddGrade(1.0);
        student.AddGrade(3.5);

        //act
        var result = student.GetStatistic();

        //assert
        Assert.Equal(1.0, result.LowGrade);
        Assert.Equal(3.5, result.HighGrade);
        Assert.Equal(2.3, result.Average, 1);
    }
    private InMemoryStudent GetStudent(string name,string surname)
    {
        return new InMemoryStudent(name,surname);
    }
}