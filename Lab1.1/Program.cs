using System;

class MyList
{
    private int[] array;
    private int count;

    public MyList(int size)
    {
        array = new int[size];
        count = 0;
    }

    public bool IsFull()
    {
        return count == array.Length;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    // Add an item to the end of the list
    public bool Add(int item)
    {
        if (IsFull())
        {
            Console.WriteLine($"Error: List is full! Cannot add item {item}.");
            return false; 
        }

        array[count] = item; 
        count++;             
        return true;         
    }

    // Print list elements to the console
    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("List is empty.");
            return;
        }

        Console.Write("List contents: ");
        for (int i = 0; i < count; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine(); 
    }

    // Remove an item by index with a left shift
    public bool RemoveAt(int index)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Error: List is empty. Nothing to remove.");
            return false;
        }

        if (index < 0 || index >= count)
        {
            Console.WriteLine($"Error: Item with index {index} does not exist.");
            return false;
        }

        int removedItem = array[index]; 

        // Shift elements to the left to fill the gap
        for (int i = index; i < count - 1; i++)
        {
            array[i] = array[i + 1]; 
        }

        count--; 
        Console.WriteLine($"Removed item: {removedItem}");
        return true; 
    }
}

class Program
{
    static void Main()
    {
        // Create a list with a maximum size of 5 elements
        MyList list = new MyList(5);

        // Insert elements
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);

        Console.WriteLine("--- Before removal ---");
        list.Print();

        Console.WriteLine("\n--- Removal process ---");
        // Remove number 20 (it is at index 1, since counting starts at zero)
        list.RemoveAt(1); 

        Console.WriteLine("\n--- After removal ---");
        // Print contents
        list.Print();
    }
}