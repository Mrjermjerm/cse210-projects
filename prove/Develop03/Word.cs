
class Word
{
    private List<string> _verses;          
    private List<List<bool>> _wordsHidden; 
    private Random _random;             

    public Word(List<string> verses)
    {
        _verses = verses;
        _wordsHidden = new List<List<bool>>();
        _random = new Random(); 

        foreach (var verse in _verses)
        {
            var wordHidden = new List<bool>();
            var words = verse.Split(' '); 
            foreach (var word in words)
            {
                wordHidden.Add(false); 
            }
            _wordsHidden.Add(wordHidden);
        }
    }

    public void GetReplaceWords()
    {
        for (int verseIndex = 0; verseIndex < _verses.Count; verseIndex++)
        {
            var words = _verses[verseIndex].Split(' ');

            List<int> availableWords = new List<int>(); 
            for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
            {
                if (!_wordsHidden[verseIndex][wordIndex]) 
                {
                    availableWords.Add(wordIndex);
                }
            }

            if (availableWords.Count > 0)
            {
                int randomIndex = availableWords[_random.Next(availableWords.Count)];
                _wordsHidden[verseIndex][randomIndex] = true; 
            }
        }

        for (int verseIndex = 0; verseIndex < _verses.Count; verseIndex++)
        {
            var words = _verses[verseIndex].Split(' ');
            for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
            {
                if (_wordsHidden[verseIndex][wordIndex])
                {
                    string word = words[wordIndex];
                    string hiddenWord = new string('_', word.Length); 
                    words[wordIndex] = hiddenWord; 
                }
            }
            Console.WriteLine(string.Join(" ", words)); 
        }
    }

    public bool AllWordsHidden()
    {
        foreach (var wordHiddenList in _wordsHidden)
        {
            if (wordHiddenList.Contains(false)) 
            {
                return false;
            }
        }
        return true; 
    }
}
