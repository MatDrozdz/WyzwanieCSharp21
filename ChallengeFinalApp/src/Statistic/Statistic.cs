public class Statistic
{
    public double HighGrade;
    public double LowGrade;
    public double Sum;
    public int Count;

    public Statistic()
    {
        Count = 0;
        Sum = 0.0;
        LowGrade = double.MaxValue;
        HighGrade = double.MinValue;
    }
    public double Average
    {
        get
        {
            return Sum / Count;
        }
    }
    public void Add(double number)
    {
        Sum += number;
        Count += 1;
        LowGrade = Math.Min(number, LowGrade);
        HighGrade = Math.Max(number, HighGrade);
    }
}