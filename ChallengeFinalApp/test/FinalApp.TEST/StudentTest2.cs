using Xunit;

namespace finalapp.test;

public class StudentTest2
{
    [Fact]
    public void GetStudentReturnDifferenetObjects()
    {
        //arrange
        var student1 = GetStudent("Mateusz","Drozdz");
        var student2 = GetStudent("Romek","Atomek");
        //act


        //assert
        Assert.NotSame(student1, student2);

    }
    [Fact]
    public void GetStudentReturnSameObjects()
    {
        //arrange
        var student1 = GetStudent("Mateusz","Drozdz");
        var student2 = student1;
        //act


        //assert
        Assert.Same(student1, student2);
        Assert.True(object.ReferenceEquals(student1, student2));
        student1.Equals(student2);
    }
    private InMemoryStudent GetStudent(string name,string surname)
    {
        return new InMemoryStudent(name,surname);
    }
}