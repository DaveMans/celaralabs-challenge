namespace CelaraLabsChallenge;

/// <summary>
/// Base finder class to look for the words in 2 dimensions, horizontal and vertical in the matrix.
/// </summary>

public class WordFinder
{
    private readonly char[][] _matrix;
    private readonly int _rows;
    private readonly int _cols;

    public WordFinder(IEnumerable<string> matrix)
    {
        _matrix = matrix.Select(row => row.ToCharArray()).ToArray();
        _rows = _matrix.Length;
        _cols = _matrix[0].Length;
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        var wordSet = new HashSet<string>(wordstream); // Unique words for search (much faster)
        var foundWords = new Dictionary<string, int>(); // Track word occurrences

        foreach (var word in wordSet)
        {
            if (ExistsInMatrix(word))
            {
                foundWords[word] = foundWords.TryGetValue(word, out int value) ? value + 1 : 1;
            }
        }

        IEnumerable<string> wordsFiltered =
            foundWords.OrderByDescending(w => w.Value).Take(10).Select(w => w.Key); // Taking top 10 most repeated words.

        return wordsFiltered;
    }

    private bool ExistsInMatrix(string word)
    {
        int wordLen = word.Length;

        for (int r = 0; r < _rows; r++)
        {
            for (int c = 0; c < _cols; c++)
            {
                if (SearchHorizontally(word, wordLen, r, c) || SearchVertically(word, wordLen, r, c)) // Final evaluation to check if the word exists
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool SearchHorizontally(string word, int wordLen, int row, int col)
    {
        if (col + wordLen <= _cols)
        {
            for (int i = 0; i < wordLen; i++)
            {
                if (_matrix[row][col + i] != word[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    private bool SearchVertically(string word, int wordLen, int row, int col)
    {
        if (row + wordLen <= _rows)
        {
            for (int i = 0; i < wordLen; i++)
            {
                if (_matrix[row + i][col] != word[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}