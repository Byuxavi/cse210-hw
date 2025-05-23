using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            
            // Split the text into words and create Word objects
            string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordArray)
            {
                _words.Add(new Word(word));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            
            // Get list of visible words (stretch challenge - don't hide already hidden words)
            List<int> visibleIndices = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden())
                {
                    visibleIndices.Add(i);
                }
            }
            
            // Hide random visible words
            int wordsToHide = Math.Min(numberToHide, visibleIndices.Count);
            for (int i = 0; i < wordsToHide; i++)
            {
                if (visibleIndices.Count > 0)
                {
                    int randomIndex = random.Next(visibleIndices.Count);
                    int wordIndex = visibleIndices[randomIndex];
                    _words[wordIndex].Hide();
                    visibleIndices.RemoveAt(randomIndex);
                }
            }
        }

        public string GetDisplayText()
        {
            string reference = _reference.GetDisplayText();
            string text = "";
            
            foreach (Word word in _words)
            {
                text += word.GetDisplayText() + " ";
            }
            
            return reference + " " + text.Trim();
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }
            return true;
        }
        
        public string GetReference()
        {
            return _reference.GetDisplayText();
        }
        
        public int GetVisibleWordCount()
        {
            int count = 0;
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    count++;
                }
            }
            return count;
        }
        
        public int GetTotalWordCount()
        {
            return _words.Count;
        }
    }
}