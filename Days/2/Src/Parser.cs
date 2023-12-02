using Days.Helpers;

public class Day2Service
{
    static int _maxBlue = 14;
    static int _maxRed = 12;
    static int _maxGreen = 13;
    
    public static int Run(string str)
    {
        var lines = str.Split("\n").Where(x => !string.IsNullOrEmpty(x));
        var games = lines.Select(x =>ParseLine(x));
        return ValidateGame(games);
    }

    private static int ValidateGame(IEnumerable<Game> games)
    {
        return games.Where(x => x.Blue <= _maxBlue && x.Red <= _maxRed && x.Green <= _maxGreen).Sum(x => x.Id);
    }

    private static Game  ParseLine(string line)
    {
        //Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        var formatString = line.Split(":");
        var grabStrings = formatString[1].Split(";");
        var colourStrings = grabStrings.SelectMany(x => x.Split(","));
        var blue = GetColourCount(colourStrings, "blue");
        var red = GetColourCount(colourStrings, "red");
        var green = GetColourCount(colourStrings, "green");

        foreach (var colourString in colourStrings)
        {
        }
        var game = new Game
        {
            Id = int.Parse(line.Substring(5, line.IndexOf(":")-5)),
            Blue = blue,
            Red = red,
            Green = green
            
        };
        return game;
    }

    public Dictionary<string, int> ColourCount = new();

    public static int GetColourCount(IEnumerable<string> input, string colour)
    {
        var first = input.Where(x => x.Contains(colour)).Select(x => x.Split(" ")[1]).OrderByDescending(x => int.Parse(x.ToString())).First();
        return int.Parse(first.ToString());
    }
}

public class Game
{
    public int Id { get; set; }
    public int Blue { get; set; }
    public int Green { get; set; }
    public int Red { get; set; }
}