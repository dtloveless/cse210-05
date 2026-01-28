using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Journal Program!");

        Journal journal = new();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string option = Console.ReadLine();
            Console.WriteLine();

            if (option == "1" || option.ToLower() == "write")
            {
                Write();
            }
            else if (option == "2" || option.ToLower() == "display")
            {
                Display();
            }
            else if (option == "3" || option.ToLower() == "load")
            {
                Load();
            }
            else if (option == "4" || option.ToLower() == "save")
            {
                Save();
            }
            else if (option == "5" || option.ToLower() == "quit")
            {
                Console.WriteLine("Thank you for using the Journal Program!");
                break;
            }
            else
            {
                Console.Write("Invalid input. Press Enter to acknowledge. ");
                Console.ReadLine();
            }
        }

        void Write()
        {
            journal.Prompt();
        }

        void Display()
        {
            journal.Display();
        }

        void Load()
        {
            Console.Write("Enter the filename: ");
            string filename = Console.ReadLine();

            using (StreamReader reader = new StreamReader(filename))
            {
                journal._entries = [];
                
                while (!reader.EndOfStream)
                {
                    Entry entry = new();

                    entry._date = reader.ReadLine();
                    entry._prompt = reader.ReadLine();
                    entry._response = reader.ReadLine();

                    journal._entries.Add(entry);

                    reader.ReadLine();
                }
            }
        }

        void Save()
        {
            Console.Write("Enter the filename: ");
            string filename = Console.ReadLine();

            using (StreamWriter file = new StreamWriter(filename))
            {                
                foreach (Entry entry in journal._entries)
                {
                    file.WriteLine(entry._date);
                    file.WriteLine(entry._prompt);
                    file.WriteLine(entry._response);

                    file.WriteLine();
                }
            }
        }
    }
}