using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int userBirthYear = PromptUserBirthYear();
        int square = SquareNumber(userNumber);
        int userAge = GetUserAge(userBirthYear);
        
        DisplayResult(userName, square, userAge);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
        return;
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();

        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine());
        
        return userNumber;
    }

    static int PromptUserBirthYear()
    {
        Console.Write("Please enter the year you were born: ");
        int userBirthYear = int.Parse(Console.ReadLine());

        return userBirthYear;
    }

    static int SquareNumber(int number)
    {
        int squareNumber = number * number;

        return squareNumber;
    }

    static int GetUserAge(int userBirthYear)
    {
        int userAge = 2026 - userBirthYear;

        return userAge;
    }

    static void DisplayResult(string userName, int squareNumber, int userAge)
    {
        Console.WriteLine($"{userName}, the square of your number is {squareNumber}");
        Console.WriteLine($"{userName}, you will turn {userAge} this year.");
    }
}