using System;

class Program
{
    static double f(double x)
    {
        return Math.Pow(x, 3) * Math.Sqrt(Math.Pow(x, 2) - 1);
    }

    static void Main()
    {
        double a = 1.0;  
        double b = 3.0;  
        double h = 0.25;  
        

        int n = (int)((b - a) / h);
        double sum = 0;

        Console.WriteLine("Left Rectangle Method");
        Console.WriteLine($"Function: y = x^3 * sqrt(x^2 - 1)");
        Console.WriteLine($"Range: [{a}, {b}], Step h: {h} (n = {n})");
        Console.WriteLine(new String('-', 55));

        for (int i = 0; i < n; i++)
        {
            double x = a + i * h; 
            sum += f(x);         
        }

        double result = sum * h;

        Console.WriteLine($"Result (Integral Value): {result:F6}");
        Console.WriteLine(new String('-', 55));
    }
}