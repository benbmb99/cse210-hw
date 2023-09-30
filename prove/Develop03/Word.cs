using System.Security.Cryptography.X509Certificates;

class Word
{
    private char[] _text;
    private bool _isHidden;
    private bool _status = true;
    private int _x = 0;
    private string _word;

    public Word(string text)
    {
        this._text = text.ToCharArray();
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        _word = "";
        if (_isHidden)
        {
            if (_status)
            {
                _x = 1;
            }
            foreach (char letter in _text)
            {
                if (_x == 1)
                {
                    _word = $"{_word}{letter}";
                    _x++;
                }
                else
                {
                    if (letter.ToString() == "." || letter.ToString() == "," || letter.ToString() == ";" || letter.ToString() == ":" || letter.ToString() == "?" || letter.ToString() == "-")
                    {
                        _word = $"{_word}{letter}";
                    }
                    else
                    {
                        _word = $"{_word}_";
                    }
                }
            }
        }
        else
        {
            //foreach(string letter in )
            _word = String.Concat(_text);
        }
        return _word;
    }

    public void SetStatus(bool status)
    {
        _status = status;
    }
}