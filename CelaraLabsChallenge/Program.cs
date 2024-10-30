using CelaraLabsChallenge;

var matrix = new List<string>
        {
            "coldwind",
            "chillbrrr",
            "warmheat",
            "frozensn",
            "sleetice",
            "snowfall",
            "breezezz",
            "rainhail"
        };

var wordStream = new List<string>
        {
            "cold", "wind", "chill", "heat", "snow", "breeze", "rain", "sun", "ice", "hail", "storm", "snow"
        };

var wordFinder = new WordFinder(matrix);

var foundWords = wordFinder.Find(wordStream);

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Top found words: \n");
Console.ForegroundColor = ConsoleColor.Green;

foreach (var word in foundWords)
{
    Console.WriteLine(word);
}

Console.ForegroundColor = ConsoleColor.White;