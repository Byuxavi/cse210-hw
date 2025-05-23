namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false; // Words start visible by default
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
            if (_isHidden)
            {
                // Create underscores matching the number of letters in the word
                string underscores = "";
                foreach (char c in _text)
                {
                    if (char.IsLetter(c))
                    {
                        underscores += "_";
                    }
                    else
                    {
                        // Keep punctuation visible
                        underscores += c;
                    }
                }
                return underscores;
            }
            else
            {
                return _text;
            }
        }
    }
}