
public class SavedStudent : StudentBase
{
    const string fileName = "StudentGrades";
    public event ParentInfoDelegate ParentInfo;
    private List<double> Grades = new List<double>();

    public SavedStudent(string name, string surname) : base(name, surname)
    {
    }

    static void SaveGrade(string name, double d)
    {
        using (var writter = File.AppendText($"{name}.csv"))
        {
            writter.WriteLine(d);
        }
        using (var writter = File.AppendText($"audit.csv"))
        {
            writter.WriteLine($"{d}\t\t{DateTime.UtcNow}");
        }
    }
    public override void AddGrade(double grade)
    {
        SaveGrade(fileName, grade);
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
                SaveGrade(fileName, result);
            }

        }
        else
        {
            if (result > 3 && result <= 6)
            {
                SaveGrade(fileName, result);
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
                            SaveGrade(fileName, 1.5);
                        }
                        break;
                    case "2+":
                        this.Grades.Add(2.5);
                        if (ParentInfo != null)
                        {
                            ParentInfo(this, new EventArgs());
                            SaveGrade(fileName, 2.5);
                        }
                        break;
                    case "3+":
                        SaveGrade(fileName, 3.5);
                        this.Grades.Add(3.5);
                        break;
                    case "4+":
                        SaveGrade(fileName, 4.5);
                        this.Grades.Add(4.5);
                        break;
                    case "5+":
                        SaveGrade(fileName, 5.5);
                        this.Grades.Add(5.5);
                        break;
                    case "6+":
                        SaveGrade(fileName, 6.5);
                        this.Grades.Add(6.5);
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

        using (var reader = File.OpenText($"{fileName}.csv"))
        {
            var line = reader.ReadLine();
            while (line != null)
            {
                var number = double.Parse(line);
                result.Add(number);
                line = reader.ReadLine();
            }
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
                isDigit = false;
        }
        if (!isDigit)
            this.Name = newName;
    }


}

