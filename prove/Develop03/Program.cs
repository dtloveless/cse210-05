using System;
using System.Text.Json.Nodes;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.Write("Please type a standard scripture reference to begin (\"Proverbs 3:5-6\"): ");
        
        string referenceText = Console.ReadLine();
        Reference reference = new(referenceText);

        string book = reference.GetBook();
        string chapter = reference.GetChapter();
        string verse = reference.GetVerse();
        string endVerse = reference.GetEndVerse();
        
        JsonNode scriptures = JsonNode.Parse(File.ReadAllText("scriptures.json"));

        string scriptureText = "";

        if (endVerse == null)
        {
            scriptureText = scriptures[book][chapter][verse].ToString();
        }
        else
        {
            int numVerses = int.Parse(endVerse) - int.Parse(verse) + 1;
            
            for (int i = 0; i < numVerses; i++)
            {
                scriptureText += scriptures[book][chapter][$"{int.Parse(verse) + i}"].ToString() + " ";
            }
        }

        Scripture scripture = new(reference, scriptureText);

        Console.Clear();
        Console.WriteLine(scripture.GetRenderedText());

        while (true)
        {
            Console.WriteLine();
            Console.Write("Press enter to continue. ");
            string userInput = Console.ReadLine();

            if(userInput.ToLower() == "quit")
            {
                Console.Clear();
                Console.WriteLine("Thank you for using the Scripture Memorizer!");
                break;
            }

            if (!scripture.GetIsCompletelyHidden())
            {
                scripture.HideWords();

                Console.Clear();
                Console.WriteLine(scripture.GetRenderedText());
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Thank you for using the Scripture Memorizer!");
                break;
            }   
        }
    }
}