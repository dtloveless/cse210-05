using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        List<int> numbers = new();
        int sum = 0;
        int largestNum = int.MinValue;
        int smallestPos = int.MaxValue;
        int number = -1;

        while(number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            
            if (number != 0)
            {
                numbers.Add(number);
                sum += number;
                if (number > largestNum)
                {
                    largestNum = number;
                }
                if (number < smallestPos && number > 0)
                {
                    smallestPos = number;
                }
            }
        }
        
        float average = (float)sum / numbers.Count;

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNum}");
        Console.WriteLine($"The smallest positive number is: {smallestPos}");
        Console.WriteLine("The sorted list is: ");

        foreach (int value in numbers)
        {
            Console.WriteLine(value);
        }
    }
}