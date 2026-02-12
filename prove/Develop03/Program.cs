/***********************************************************************************
* Scripture Memorizer
* by Daniel Loveless
* for CSE 210-05 @ BYU-Idaho, Winter 2026
*
* This program assists the user in memorizing a specified scripture by hiding 
* words several at a time for the user to recite until the scripture is completely
* hidden and hopefully fully memorized. I exceeded the minimum requirements by
* allowing the user to simply provide any scripture reference and have the text of
* those verses automatically populate. Users can also unhide words that were 
* previously hidden.
* 
* Credit to Ben Crowder who wrote a JSON file containing the entire Standard Works 
* of The Church of Jesus Christ of Latter-day Saints.
* https://github.com/bcbooks/scriptures-json
***********************************************************************************/

using System;
using System.Text.Json.Nodes;

class Program
{
    static void Main(string[] args)
    {
        /* Program Start Behavior */

        // Gets scripture reference from user and creates reference object
        Reference reference;
        string scriptureText = "";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Scripture Memorizer!");
            Console.Write("Please type a standard scripture reference to begin (\"Proverbs 3:5-6\"): ");

            string referenceText = Console.ReadLine();
            
            try
            {
                reference = new Reference(referenceText);

                string book = reference.GetBook();
                string chapter = reference.GetChapter();
                string verse = reference.GetVerse();
                string endVerse = reference.GetEndVerse();
                

                // Fetches the text of the corresponding verses from JSON file
                JsonNode scriptures = JsonNode.Parse(File.ReadAllText("scriptures.json"));

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
                break;
            }
            catch
            {
                Console.Write("An error occured. Check your spelling and try again. ");
                Console.ReadLine();
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