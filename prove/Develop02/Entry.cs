public class Entry()
{
    public string _date = "";
    public string _prompt = "";
    public string _response = "";

    public void Display()
    {
        Console.WriteLine(_date);
        Console.WriteLine(_prompt);
        Console.WriteLine(_response);
    }

    public void Prompt()
    {
        Console.WriteLine(_prompt);
        Console.Write("> ");
        _response = Console.ReadLine();
    }
}