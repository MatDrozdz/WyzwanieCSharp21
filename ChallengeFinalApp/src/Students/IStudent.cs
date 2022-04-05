public interface IStudent
{
    string Name { get; set; }
    string Surname { get; set; }
    event ParentInfoDelegate ParentInfo;
    void AddGrade(double grade);
    void AddGrade(string s);
    Statistic GetStatistic();
    void ShowStatistic();
}

