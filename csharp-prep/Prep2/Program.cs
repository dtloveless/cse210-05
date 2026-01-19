using System;
using System.Diagnostics;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Console.Write("What percent grade did you earn for the course? ");
        float percentGrade = float.Parse(Console.ReadLine());

        string letterGrade = "";

        if (percentGrade >= 90)
        {
            letterGrade = "A";
        }
        else if (percentGrade >= 80)
        {
            letterGrade = "B";
        }
        else if (percentGrade >= 70)
        {
            letterGrade = "C";
        }
        else if (percentGrade >= 60)
        {
            letterGrade = "D";
        }
        else if (percentGrade < 60)
        {
            letterGrade = "F";
        }

        string sign;

        if (letterGrade != "A" && letterGrade != "F")
        {
            if (percentGrade % 10 >= 7)
            {
                sign = "+";
            }
            else if (percentGrade % 10 < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }
        else
        {
            sign = "";
        }

        bool pass = false;

        if (percentGrade >= 70)
        {
            pass = true;
        }

        Console.WriteLine($"Letter grade earned: {letterGrade}{sign}");
        
        if (pass)
        {
            Console.WriteLine("You passed! Congratulations!");
        }
        else
        {
            Console.WriteLine("You failed. Better luck next time!");
        }
    }
}