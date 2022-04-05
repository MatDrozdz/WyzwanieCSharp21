using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFinalApp
{
    public static class GradeBook
    {

        public static void CreateGradeBook()
        {
            int menuChoise;
            bool correctMenu;
            do
            {
                Console.Clear();
                Console.WriteLine($"Hello. Please choose option:\n\t1.Add student and grade.\n\t2.Exit");
                if (int.TryParse(Console.ReadLine(), out menuChoise)
                    && (menuChoise == 1 || menuChoise == 2))
                {
                    correctMenu = true;
                }
                else
                {
                    Console.WriteLine($"Incorrect choise. Please try again");
                    Console.ReadKey();
                    correctMenu = false;
                }
            }
            while (!correctMenu);
            switch (menuChoise)
            {
                case 1:
                    CreateStudentAndGrade();
                    break;
                case 2:
                    Console.WriteLine($"Good Bye!");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }
        private static void CreateStudentAndGrade()
        {
            string name = StringValidation($"Please enter student name:");
            string surname = StringValidation($"Please enter student surname");
            Console.Clear();

            InMemoryStudent student = new InMemoryStudent(name, surname);

            student.ParentInfo += SendInfromation;

            EnterGrade(student);
            Console.Clear();
            var studentStatistics = student.GetStatistic();

            student.ShowStatistic();
        }
        private static string StringValidation(string message)
        {
            bool isValid = false;
            string nameOrSurname;
            do
            {
                Console.Clear();
                Console.WriteLine(message);
                nameOrSurname = Console.ReadLine().Trim();
                foreach (var c in nameOrSurname)
                {
                    if (char.IsDigit(c))
                    {
                        isValid = false;
                        System.Console.WriteLine("Name/Surname can't have a digit!");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(nameOrSurname))
                        {
                            isValid = false;
                            Console.WriteLine($"Name/Surname is empty.Please enter again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                }
            }
            while (!isValid);
            return nameOrSurname;
        }
        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade for\t {student.Name.ToUpper()} \nor press Q to show statistics and exit:\n");
                var input = Console.ReadLine();
                if (input == "q" || input == "Q")
                {
                    break;
                }
                else
                {
                    try
                    {
                        student.AddGrade(input);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        System.Console.WriteLine("Invalid value");
                    }
                }
            }
        }
        private static void SendInfromation(object sender, EventArgs args)
        {
            Console.WriteLine("Need to inform parents about this grade!");
        }

    }
}
