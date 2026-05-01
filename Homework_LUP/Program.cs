using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("LUP Decomposition (Variant 15)");
        
        Console.Write("Enter the number of equations (n): ");
        int n = int.Parse(Console.ReadLine() ?? "3");

        double[,] A = new double[n, n];
        double[,] L = new double[n, n];
        double[,] U = new double[n, n];
        double[,] P = new double[n, n];
        double[] b = new double[n];
        int[] pi = new int[n];

        for (int i = 0; i < n; i++)
        {
            P[i, i] = 1;
            pi[i] = i;
        }

        Console.WriteLine("Enter the coefficients of matrix A (row by row, separated by space):");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Row {i + 1}: ");
            string[] parts = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < n; j++)
            {
                A[i, j] = double.Parse(parts[j]);
                U[i, j] = A[i, j];
            }
        }

        Console.Write("Enter the elements of vector b (separated by space): ");
        string[] bParts = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < n; i++)
        {
            b[i] = double.Parse(bParts[i]);
        }

        for (int k = 0; k < n; k++)
        {
            double p = 0;
            int kPrime = k;
            for (int i = k; i < n; i++)
            {
                if (Math.Abs(U[i, k]) > p)
                {
                    p = Math.Abs(U[i, k]);
                    kPrime = i;
                }
            }

            if (p == 0)
            {
                Console.WriteLine("Error: Singular matrix!");
                return;
            }

            int tempPi = pi[k];
            pi[k] = pi[kPrime];
            pi[kPrime] = tempPi;

            for (int i = 0; i < n; i++)
            {
                double temp = U[k, i];
                U[k, i] = U[kPrime, i];
                U[kPrime, i] = temp;
            }

            for (int i = 0; i < k; i++)
            {
                double temp = L[k, i];
                L[k, i] = L[kPrime, i];
                L[kPrime, i] = temp;
            }

            for (int i = 0; i < n; i++)
            {
                double temp = P[k, i];
                P[k, i] = P[kPrime, i];
                P[kPrime, i] = temp;
            }

            for (int i = k + 1; i < n; i++)
            {
                L[i, k] = U[i, k] / U[k, k];
                for (int j = k; j < n; j++)
                {
                    U[i, j] = U[i, j] - L[i, k] * U[k, j];
                }
            }
        }

        for (int i = 0; i < n; i++) L[i, i] = 1;

        Console.WriteLine("\nInitial Matrix A:");
        PrintMatrix(A, n);
        
        Console.WriteLine("\nLower Triangular Matrix L:");
        PrintMatrix(L, n);
        
        Console.WriteLine("\nUpper Triangular Matrix U:");
        PrintMatrix(U, n);
        
        Console.WriteLine("\nPermutation Matrix P:");
        PrintMatrix(P, n);

        double[] y = new double[n];
        for (int i = 0; i < n; i++)
        {
            double sum = 0;
            for (int j = 0; j < i; j++)
            {
                sum += L[i, j] * y[j];
            }
            y[i] = b[pi[i]] - sum; 
        }

        double[] x = new double[n];
        for (int i = n - 1; i >= 0; i--)
        {
            double sum = 0;
            for (int j = i + 1; j < n; j++)
            {
                sum += U[i, j] * x[j];
            }
            x[i] = (y[i] - sum) / U[i, i];
        }

        Console.WriteLine("\nSolution:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"x{i + 1} = {Math.Round(x[i], 4)}");
        }
    }

    static void PrintMatrix(double[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{Math.Round(matrix[i, j], 2),8} ");
            }
            Console.WriteLine();
        }
    }
}