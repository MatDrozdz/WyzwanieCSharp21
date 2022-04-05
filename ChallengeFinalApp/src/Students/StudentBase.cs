
public delegate void ParentInfoDelegate(object sender, EventArgs e);
public abstract class StudentBase : IStudent
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public StudentBase(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public event ParentInfoDelegate ParentInfo;
    public abstract void AddGrade(double grade);
    public abstract void AddGrade(string s);
    public virtual Statistic GetStatistic()
    {
        return new Statistic();
    }
    public virtual void ShowStatistic()
    {
    }
}

