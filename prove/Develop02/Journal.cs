public class Journal()
{
    public List<Entry> _entries = new();
    public List<string> _prompts = [

        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    ];

    public void Display()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            _entries[i].Display();
            if (i != _entries.Count - 1)
            {
                Console.WriteLine();
            }
        }
    }

    public void Prompt()
    {
        Entry entry = new();

        entry._date = DateTime.Now.ToString();

        if (_prompts.Count > 0)
        {
            Random rand = new();
            int i = rand.Next(_prompts.Count);
            entry._prompt = _prompts[i];
            _prompts.RemoveAt(i);
        }
        else
        {
            entry._prompt = "And how does that make you feel?";
        }

        entry.Prompt();

        _entries.Add(entry);
    }
}