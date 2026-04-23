using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Gender { get; set; }
    public int CertificateId { get; set; } 
    public double AverageGrade { get; set; }

    public Student(string lastName, string firstName, string gender, int certificateId, double averageGrade)
    {
        LastName = lastName;
        FirstName = firstName;
        Gender = gender;
        CertificateId = certificateId;
        AverageGrade = averageGrade;
    }

    public override string ToString()
    {
        return String.Format("| {0,-10} | {1,-10} | Sex: {2,-6} | ID: {3,-5} | Grade: {4,-4:F1} |", 
            LastName, FirstName, Gender, CertificateId, AverageGrade);
    }
}

class Program
{
    
    static Student BinarySearch(List<Student> students, int targetId)
    {
        int left = 0;
        int right = students.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (students[mid].CertificateId == targetId)
                return students[mid];

            if (students[mid].CertificateId < targetId)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }

    static void Main()
    {
        
        List<Student> students = new List<Student>
        {
            new Student("Kozak", "Maxim", "Male", 1003, 9.5),
            new Student("Bondar", "Olena", "Female", 1008, 9.3),
            new Student("Sidorov", "Ihor", "Male", 1010, 8.5), 
            new Student("Petrenko", "Anna", "Female", 1001, 9.8),
            new Student("Ivanov", "Oleg", "Male", 1005, 9.1)  
        };

        
        students = students.OrderBy(s => s.CertificateId).ToList();

        Console.WriteLine("\n=== SORTED STUDENT LIST (By Certificate ID) ===");
        Console.WriteLine(new String('-', 70));
        foreach (var s in students) Console.WriteLine(s);
        Console.WriteLine(new String('-', 70));

       
        int searchId = 1008; 
        Console.WriteLine($"\nSearching for Certificate ID: {searchId}...");

        Student found = BinarySearch(students, searchId);

        if (found != null)
        {
            Console.WriteLine($"SUCCESS: Found {found.LastName} {found.FirstName}");
            
            
            if (found.AverageGrade > 9.2)
            {
                Console.WriteLine($"RESULT: Average grade ({found.AverageGrade}) is above 9.2.");
                Console.WriteLine($"Student gender is: {found.Gender}");
            }
            else
            {
                Console.WriteLine($"RESULT: Average grade ({found.AverageGrade}) is NOT above 9.2.");
            }
        }
        else
        {
            Console.WriteLine("Student with this Certificate ID was not found.");
        }
        Console.WriteLine();
    }
}