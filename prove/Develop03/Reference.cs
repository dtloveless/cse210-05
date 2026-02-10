public class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;
    private string _endVerse;

    public Reference(string referenceText)
    {
        string[] parts = referenceText.Split(':');

        string bookChapterString = parts[0];
        int lastSpace = bookChapterString.LastIndexOf(' ');
        _book = bookChapterString.Substring(0, lastSpace);
        _chapter = bookChapterString.Substring(lastSpace + 1);

        string versesString = parts[1];
        if (versesString.Contains('-'))
        {
            string[] verses = versesString.Split('-');
            _verse = verses[0];
            _endVerse = verses[1];
        }
        else
        {
            _verse = versesString;
        }
    }

    public Reference(string book, string chapter, string verse, string endVerse = null)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetRenderedText()
    {
        if (_endVerse != null)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}";
        }
    }

    public string GetBook()
    {
        return _book;
    }

    public string GetChapter()
    {
        return _chapter;
    }

    public string GetVerse()
    {
        return _verse;
    }

    public string GetEndVerse()
    {
        return _endVerse;
    }
}