public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text, bool isHidden = false)
    {
        _text = text;
        _isHidden = isHidden;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool GetIsHidden()
    {
        return _isHidden;
    }

    public string GetRenderedText()
    {
        string renderedText = "";

        if (_isHidden)
        {
            foreach (char letter in _text)
            {
                if (char.IsLetter(letter))
                {
                    renderedText += '_';
                }
                else
                {
                    renderedText += letter;
                }
            }
        }
        else
        {
            renderedText = _text;
        }

        return renderedText;
    }
}