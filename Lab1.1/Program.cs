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
    public bool Add(int item)
    {
        if (IsFull())
        {
            Console.WriteLine($"Ошибка: Список переполнен! Невозможно добавить число {item}.");
            return false; 
        }

        array[count] = item; 
        count++;             
        return true;         
    }

    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Список пуст.");
            return;
        }

        Console.Write("Содержимое списка: ");
        for (int i = 0; i < count; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine(); 
    }

    public bool RemoveAt(int index)
    {
        if (IsEmpty())
        {
            Console.WriteLine("Ошибка: Список пуст. Удалять нечего.");
            return false;
        }

        if (index < 0 || index >= count)
        {
            Console.WriteLine($"Ошибка: Элемента с индексом {index} не существует.");
            return false;
        }

        int removedItem = array[index]; 

        for (int i = index; i < count - 1; i++)
        {
            array[i] = array[i + 1]; 
        }

        count--; 
        Console.WriteLine($"Удален элемент: {removedItem}");
        return true; 
    }
}

class Program
{
    static void Main()
    {
        MyList list = new MyList(5);

        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);

        Console.WriteLine("--- До видалення ---");
        list.Print();

        Console.WriteLine("\n--- Процес видалення ---");
        list.RemoveAt(1); 

        Console.WriteLine("\n--- Після видалення ---");
        list.Print();
    }
}