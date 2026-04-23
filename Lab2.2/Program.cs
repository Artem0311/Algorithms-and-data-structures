using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "words.txt";
            string pattern = @"^\[[\+\-][0-9A-Z]+\]$";

            Console.WriteLine("Search pattern: " + pattern);
            Console.WriteLine();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Error: File 'words.txt' not found.");
                    return;
                }

                string[] words = File.ReadAllLines(filePath);
                bool foundMatch = false;

                Console.WriteLine("Matching words:");
                foreach (string word in words)
                {
                    if (Regex.IsMatch(word, pattern))
                    {
                        Console.WriteLine("> " + word);
                        foundMatch = true;
                    }
                }

                if (!foundMatch)
                {
                    Console.WriteLine("No matches found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}