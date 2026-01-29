using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Fraction fraction1 = new();
        // Console.WriteLine(fraction1.GetFractionString());
        // Console.WriteLine(fraction1.GetDecimalValue());

        // Fraction fraction2 = new(5);
        // Console.WriteLine(fraction2.GetFractionString());
        // Console.WriteLine(fraction2.GetDecimalValue());

        // Fraction fraction3 = new(3, 4);
        // Console.WriteLine(fraction3.GetFractionString());
        // Console.WriteLine(fraction3.GetDecimalValue());

        // Fraction fraction4 = new(1, 3);
        // Console.WriteLine(fraction4.GetFractionString());
        // Console.WriteLine(fraction4.GetDecimalValue());

        Random random = new();

        for (int i = 0; i < 20; i++)
        {
            Fraction fraction = new();

            int top = random.Next(100);
            fraction.SetNumerator(top);

            int bottom = random.Next(100);
            fraction.SetDenominator(bottom);

            string fractionString = fraction.GetFractionString();
            double fractionDecimal = fraction.GetDecimalValue();

            Console.WriteLine($"Fraction {i + 1}: string: {fractionString} decimal: {fractionDecimal}");
        }
    }
}