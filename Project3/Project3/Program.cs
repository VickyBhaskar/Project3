// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "C:\\Users\\vicky\\OneDrive\\Desktop\\Mphasis\\Project3\\students.txt";

        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Display header
            Console.WriteLine("Name\t\tClass");

            // Display each student's data
            List<Student> students = new List<Student>();

            foreach (string line in lines)
            {
                string[] studentData = line.Split(',');

                string name = studentData[0].Trim();
                string studentClass = studentData[1].Trim();

                Student student = new Student { Name = name, Class = studentClass };
                students.Add(student);
            }

            // Sort students by name
            students = students.OrderBy(s => s.Name).ToList();

            // Display sorted student data
            DisplayStudents(students);

            // Search for a student by name
            Console.Write("\nEnter a name to search: ");
            string searchName = Console.ReadLine().Trim();

            // Perform case-insensitive search
            Student foundStudent = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (foundStudent != null)
            {
                Console.WriteLine($"Student found: {foundStudent.Name}, Class: {foundStudent.Class}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Make sure the file exists and try again.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void DisplayStudents(List<Student> students)
    {
        foreach (Student student in students)
        {
            Console.WriteLine($"{student.Name}\t\t{student.Class}");
        }
    }
}

class Student
{
    public string Name { get; set; }
    public string Class { get; set; }
}

