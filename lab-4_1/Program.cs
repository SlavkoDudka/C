using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Student
{
    public string LastName { get; set; }
    public int GradeBookNumber { get; set; }
    public int Rating { get; set; }

    public Student(string lastname, int gradebooknumber, int rating)
    {
        LastName = lastname;
        GradeBookNumber = gradebooknumber;
        Rating = rating;
    }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>();
        students.Add(new Student("Koptelov", 1234, 90));
        students.Add(new Student("Jarovi", 5678, 80));
        students.Add(new Student("Kosolapov", 9012, 70));
        students.Add(new Student("Lazor", 3456, 60));
        students.Add(new Student("Teklian", 7890, 50));
        students.Add(new Student("Odovichuk", 1234, 40));
        students.Add(new Student("Semchuk", 5678, 30));
        students.Add(new Student("Ivanov", 9012, 20));
        students.Add(new Student("Dudka", 3456, 10));

        students.Sort((x, y) => y.Rating - x.Rating);

        Console.WriteLine("| Last Name | Grade Book Number | Rating |");
        Console.WriteLine("|----------|-------------------|--------|");
        foreach (Student student in students)
        {
            Console.WriteLine($"| {student.LastName} | {student.GradeBookNumber} | {student.Rating} |");
        }

        int totalRating = 0;
        foreach (Student student in students)
        {
            totalRating += student.Rating;
        }
        int averageRating = totalRating / students.Count;

        int belowAverageRatingCount = 0;
        foreach (Student student in students)
        {
            if (student.Rating < averageRating)
            {
                belowAverageRatingCount++;
            }
        }

        Console.WriteLine("The average rating of the group is {0}", averageRating);
        Console.WriteLine("There are {0} students with below average rating", belowAverageRatingCount);
    }
}
