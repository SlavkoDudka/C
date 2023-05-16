using System;
using System.Collections.Generic;
using System.Linq;

public interface IStudentDatabase
{
    void AddStudent(string lastName, string studentID, int rating);
    void SortByRatingDescending();
    void DisplayTable();
    double CalculateAverageRating();
    int CountStudentsBelowAverageRating();
}

public class StudentDatabase : IStudentDatabase
{
    private List<Student> students;

    public StudentDatabase()
    {
        students = new List<Student>();
    }

    public void AddStudent(string lastName, string studentID, int rating)
    {
        students.Add(new Student(lastName, studentID, rating));
    }

    public void SortByRatingDescending()
    {
        students = students.OrderByDescending(s => s.Rating).ToList();
    }

    public void DisplayTable()
    {
        Console.WriteLine("{0,-15} {1,-15} {2,-10}", "Last Name", "Student ID", "Rating");
        foreach (var student in students)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-10}", student.LastName, student.StudentID, student.Rating);
        }
    }

    public double CalculateAverageRating()
    {
        return students.Average(s => s.Rating);
    }

    public int CountStudentsBelowAverageRating()
    {
        double averageRating = CalculateAverageRating();
        return students.Count(s => s.Rating < averageRating);
    }
}

public class Student
{
    public string LastName { get; set; }
    public string StudentID { get; set; }
    public int Rating { get; set; }

    public Student(string lastName, string studentID, int rating)
    {
        LastName = lastName;
        StudentID = studentID;
        Rating = rating;
    }
}

class Program
{
    static void Main(string[] args)
    {
        IStudentDatabase studentDatabase = new StudentDatabase();

        studentDatabase.AddStudent("Koptelov", "S001", 85);
        studentDatabase.AddStudent("Jiarovi", "J002", 92);
        studentDatabase.AddStudent("Teklian", "W003", 78);
        studentDatabase.AddStudent("Odovichuk", "J004", 90);
        studentDatabase.AddStudent("Dudka", "B005", 81);

        studentDatabase.SortByRatingDescending();

        studentDatabase.DisplayTable();

        double averageRating = studentDatabase.CalculateAverageRating();
        Console.WriteLine("Average Rating: {0}", averageRating);

        int countBelowAverage = studentDatabase.CountStudentsBelowAverageRating();
        Console.WriteLine("Number of Students below Average Rating: {0}", countBelowAverage);

        Console.ReadLine();
    }
}