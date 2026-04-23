using System;
using System.Diagnostics;
using System.Collections.Generic;

class Program
{
    static void QuickSort3Way(int[] a, int lo, int hi)
    {
        if (hi <= lo) return;
        int lt = lo, gt = hi;
        int v = a[lo];
        int i = lo + 1;
        while (i <= gt)
        {
            if (a[i] < v) Swap(a, lt++, i++);
            else if (a[i] > v) Swap(a, i, gt--);
            else i++;
        }
        QuickSort3Way(a, lo, lt - 1);
        QuickSort3Way(a, gt + 1, hi);
    }

    static void Swap(int[] a, int i, int j)
    {
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }

    static long MeasureTime(int size)
    {
        int[] data = new int[size];
        Random rand = new Random();
        for (int i = 0; i < size; i++) data[i] = rand.Next(0, 1000000);

        Stopwatch sw = new Stopwatch();
        sw.Start();
        QuickSort3Way(data, 0, data.Length - 1);
        sw.Stop();
        
        return (long)(sw.Elapsed.TotalMilliseconds * 1000000);
    }

    static void Main()
    {
        int n = 100;
        int[] sizes = { n, n * n, n * n * 100 }; 
        Console.WriteLine("\n=== ALGORITHM ANALYSIS (Lab 1.6 - Variant 15) ===");
        Console.WriteLine(new String('-', 45));
        Console.WriteLine("| Elements Count (N) | Time (Nanoseconds)   |");
        Console.WriteLine(new String('-', 45));

        foreach (int size in sizes)
        {
            long time = MeasureTime(size);
            Console.WriteLine("| {0,-18} | {1,-20} |", size, time);
        }
        Console.WriteLine(new String('-', 45));
        Console.WriteLine("\nDone! Copy these values to Excel to build your graph.");
    }
}