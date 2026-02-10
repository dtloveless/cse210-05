public class Scripture
{
    private Reference _reference;
    private List<Word> _words = [];
    private int _numHidden;
    private bool _isCompletelyHidden;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }

        _numHidden = 0;
        _isCompletelyHidden = false;
    }

    public void HideWords(int numToHide = 3)
    {
        for (int i = 0; i < numToHide; i++)
        {
            Random rand = new();
            while (_numHidden < _words.Count)
            {
                int index = rand.Next(_words.Count);
                if(!_words[index].GetIsHidden())
                {
                    _words[index].Hide();
                    _numHidden += 1;
                    break;
                }
            }
            if (_numHidden >= _words.Count)
            {
                _isCompletelyHidden = true;
                break;
            }
        }
    }

    public bool GetIsCompletelyHidden()
    {
        return _isCompletelyHidden;
    }

    public string GetRenderedText()
    {
        string referenceText = _reference.GetRenderedText();
        string scriptureText = "";

        foreach (Word word in _words)
        {
            scriptureText += word.GetRenderedText() + " ";
        }

        return referenceText + " " + scriptureText;
    }
}