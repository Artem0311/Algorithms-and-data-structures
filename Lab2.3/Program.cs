using System;

namespace Lab2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Laboratory work 2.3 (Variant 15)");
            Console.WriteLine("Combinatorial problem type: Permutation without repetition");
            Console.WriteLine();

            Console.Write("Enter the number of student groups: ");
            string input = Console.ReadLine() ?? string.Empty;

            try
            {
                int n = int.Parse(input);

                if (n <= 0)
                {
                    Console.WriteLine("Error: Number of groups must be greater than 0.");
                    return;
                }

                int groupsToDistribute = n - 1;
                long ways = CalculateFactorial(groupsToDistribute);

                Console.WriteLine("Number of ways to distribute the groups: " + ways);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static long CalculateFactorial(int number)
        {
            if (number <= 1)
                return 1;
            
            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}