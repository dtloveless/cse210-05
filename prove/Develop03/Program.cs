using System;
using System.Text.Json.Nodes;

class Program
{
    static void Main(string[] args)
    {
        /* Program Start Behavior */

        // Gets scripture reference from user and creates reference object
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.Write("Please type a standard scripture reference to begin (\"Proverbs 3:5-6\"): ");
        
        string referenceText = Console.ReadLine();
        Reference reference = new(referenceText);

        string book = reference.GetBook();
        string chapter = reference.GetChapter();
        string verse = reference.GetVerse();
        string endVerse = reference.GetEndVerse();
        
        // Fetches the text of the corresponding verses from JSON file
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

        // Creates scripture object
        Scripture scripture = new(reference, scriptureText);


        /* Program Run Behavior */

        Console.Clear();
        Console.WriteLine(scripture.GetRenderedText());

        while (true)
        {
            Console.WriteLine();
            Console.Write("Press enter to hide words, type 'show' to reveal words, or type 'quit' to end. ");
            string userInput = Console.ReadLine();

            if(userInput.ToLower() == "quit" || scripture.GetIsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("Thank you for using the Scripture Memorizer!");
                break;
            }
            else if (userInput.ToLower() == "show")
            {
                scripture.ShowWords();

                Console.Clear();
                Console.WriteLine(scripture.GetRenderedText());
            }
            else
            {
                scripture.HideWords();

                Console.Clear();
                Console.WriteLine(scripture.GetRenderedText());
            }
        }
    }
}