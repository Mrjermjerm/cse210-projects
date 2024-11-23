

using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

class Word
{
    private Random _randomWord = new Random();
    private List<int> _hiddenWords = new List<int>();
    private List<string> _verses;


    public Word(List<string> verses)
    {
        _verses = verses;
    }
    
    private string ReplaceWords()
    {
        string verse = _verses[0];
        string[] words = verse.Split(' ');

        int randomWordsIndex = -1;
        while (randomWordsIndex == -1 && _hiddenWords.Count < words.Length)
        {
            randomWordsIndex = _randomWord.Next(words.Length);
            
            if (_hiddenWords.Contains(randomWordsIndex))
            {
                randomWordsIndex = -1;
            }
        }

        if (_hiddenWords.Count >= words.Length)
        {
            return string.Join(" ", words);
        }

        if (randomWordsIndex != -1)
        {
            words[randomWordsIndex] = new string('_', words[randomWordsIndex].Length);
            _hiddenWords.Add(randomWordsIndex);
        }
        _verses[0] = string.Join(" ", words);
        return string.Join(" ", words);
    }

    public void GetReplaceWords()
    {
        string hiddenWords = ReplaceWords();
        Console.WriteLine(hiddenWords);
    }

    public bool AllWordsHidden()
    {
        return _hiddenWords.Count == _verses[0].Split(' ').Length;
    }
}