using System;

class Circle
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Radius { get; private set; }

    public Circle(double x, double y, double radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Circle ({X:F1}, {Y:F1}) | R: {Radius:F1} | P: {GetPerimeter():F2}");
    }
}

class HashTable
{
    private Circle[] table;
    private int size;

    public HashTable(int size)
    {
        this.size = size;
        table = new Circle[size];
    }

    private int HashFunction(double perimeter)
    {
        return (int)(Math.Floor(perimeter)) % size; 
    }

    public bool Insert(Circle circle)
    {
        int index = HashFunction(circle.GetPerimeter());

        if (table[index] != null)
        {
            Console.WriteLine($"  [!] Collision at index {index}! Cannot insert this circle.");
            return false;
        }

        table[index] = circle;
        Console.WriteLine($"  [+] Successfully inserted at index {index}.");
        return true;
    }

    public void PrintTable()
    {
        Console.WriteLine("\n=== Hash Table Contents ===");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"[{i}]: ");
            if (table[i] == null)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                table[i].PrintInfo();
            }
        }
        Console.WriteLine("===========================\n");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the size of the Hash Table: ");
        
        int tableSize;
        if (!int.TryParse(Console.ReadLine(), out tableSize) || tableSize <= 0)
        {
            Console.WriteLine("Invalid size. Defaulting to 7.");
            tableSize = 7;
        }

        HashTable myHashTable = new HashTable(tableSize);
        Random random = new Random(); 

        Console.WriteLine("\n--- Starting Insertion Process ---");
        
        for (int i = 1; i <= 5; i++) 
        {
            double x = random.NextDouble() * 10;
            double y = random.NextDouble() * 10;
            double radius = random.NextDouble() * 5 + 1; 

            Circle randomCircle = new Circle(x, y, radius);
            Console.WriteLine($"\nTrying Circle {i} (Perimeter: {randomCircle.GetPerimeter():F2})...");
            
            myHashTable.Insert(randomCircle);
        }

        myHashTable.PrintTable();
    }
}