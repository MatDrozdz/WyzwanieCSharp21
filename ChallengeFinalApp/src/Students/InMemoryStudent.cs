public class InMemoryStudent : StudentBase
{
    public event ParentInfoDelegate ParentInfo;
    private List<double> Grades = new List<double>();

    public InMemoryStudent(string name, string surname) : base(name, surname)
    {
    }
    public override void AddGrade(double grade)
    {
        this.Grades.Add(grade);
    }
    public override void AddGrade(string s)
    {
        int result;
        int.TryParse(s, out result);
        if (result > 0 && result <= 3)
        {
            this.Grades.Add(result);
            if (ParentInfo != null)
            {
                ParentInfo(this, new EventArgs());
            }

        }
        else
        {
            if (result > 3 && result <= 6)
            {
                this.Grades.Add(result);
            }
            else
            {
                switch (s)
                {
                    case "1+":
                        this.Grades.Add(1.5);
                        if (ParentInfo != null)
                        {
                            ParentInfo(this, new EventArgs());
                        }
                        break;
                    case "+1":
                        this.Grades.Add(1.5);
                        if (ParentInfo != null)
                        {
                            ParentInfo(this, new EventArgs());
                        }
                        break;
                    case "2+":
                        this.Grades.Add(2.5);
                        if (ParentInfo != null)
                        {
                            ParentInfo(this, new EventArgs());
                        }
                        break;
                    case "+2":
                        this.Grades.Add(1.5);
                        if (ParentInfo != null)
                        {
                            ParentInfo(this, new EventArgs());
                        }
                        break;
                    case "3+":
                        this.Grades.Add(3.5);
                        break;
                    case "+3":
                        this.Grades.Add(3.5);
                        break;
                    case "4+":
                        this.Grades.Add(4.5);
                        break;
                    case "+4":
                        this.Grades.Add(3.5);
                        break;
                    case "5+":
                        this.Grades.Add(5.5);
                        break;
                    case "+5":
                        this.Grades.Add(3.5);
                        break;
                    case "6+":
                        this.Grades.Add(6.5);
                        break;
                    case "+6":
                        this.Grades.Add(3.5);
                        break;
                    default:
                        throw new ArgumentException("Invalid value!");
                }
            }
        }
    }
    public override Statistic GetStatistic()
    {
        var result = new Statistic();
        for (var index = 0; index < Grades.Count; index++)
        {
            result.Add(Grades[index]);
        }
        return result;
    }
    public override void ShowStatistic()
    {
        Console.WriteLine($"STUDENT: {Name} {Surname}\nHigh Grade: {GetStatistic().HighGrade}\nLow Grade: {GetStatistic().LowGrade}\nAverage: {GetStatistic().Average}");
    }
    public void ChangeName(string newName)
    {
        bool isDigit = false;
        foreach (var c in newName)
        {
            if (char.IsDigit(c))
            {
                isDigit = true;
                System.Console.WriteLine("New name have a digit!\nName wasn't changed!");
                break;
            }
            else
            {
                isDigit = false;
            }
        }
        if (!isDigit)
        {
            this.Name = newName;
        }
    }
}

