using System;

class Student
{
    public int RoomNumber { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public Student(int roomNumber, string lastName, string firstName)
    {
        RoomNumber = roomNumber;
        LastName = lastName;
        FirstName = firstName;
    }

    
    public override string ToString()
    {
        return String.Format("| {0,-11} | {1,-12} | {2,-10} |", RoomNumber, LastName, FirstName);
    }
}

class Program
{
    static void ShakerSort(Student[] array)
    {
        bool swapped = true;
        int start = 0;
        int end = array.Length - 1;

        while (swapped)
        {
            swapped = false;

            
            for (int i = start; i < end; ++i)
            {
                if (array[i].RoomNumber > array[i + 1].RoomNumber)
                {
                    Student temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }

            
            if (!swapped) break;

            swapped = false;
            end = end - 1; 

            
            for (int i = end - 1; i >= start; --i)
            {
                
                if (array[i].RoomNumber > array[i + 1].RoomNumber)
                {
                    Student temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swapped = true;
                }
            }

            
        }
    }

    static void PrintArray(Student[] array)
    {
        Console.WriteLine(new String('-', 43));
        Console.WriteLine("| Room Number | Last Name    | First Name |");
        Console.WriteLine(new String('-', 43));
        foreach (Student s in array)
        {
            Console.WriteLine(s.ToString());
        }
        Console.WriteLine(new String('-', 43));
    }

    static void Main()
    {
        Student[] students = new Student[]
        {
            new Student(305, "Kovalenko", "Oleg"),
            new Student(102, "Petrenko", "Anna"),
            new Student(512, "Boiko", "Ihor"),
            new Student(204, "Melnyk", "Ivan"),
            new Student(410, "Tkachenko", "Vlad"),
            new Student(102, "Shevchuk", "Olena") 
        };

        Console.WriteLine("\n=== BEFORE SORTING ===");
        PrintArray(students);

        ShakerSort(students);

        Console.WriteLine("\n=== AFTER SHAKER SORT (Ascending) ===");
        PrintArray(students);
        Console.WriteLine();
    }
}