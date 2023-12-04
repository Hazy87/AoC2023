using Days.Helpers;
using Flurl.Util;

public class Day4Service
{
    public static int Run(string str)
    {
        var cards = str.NewLineSplit().Where(x=> !string.IsNullOrEmpty(x)).Select(x =>
        {
            var idSplit = x.Split(":");
            var numberSplit = idSplit[1].Split("|");
            return new Card()
            {
                Id = int.Parse(idSplit[0].Split(" ").Where(x=> !string.IsNullOrEmpty(x)).ToArray()[1]),
                CardNumbers = numberSplit[1].Split(" ").Where(x=> !string.IsNullOrEmpty(x)).Select(y => int.Parse(y)).ToList(),
                WinningNumbers = numberSplit[0].Split(" ").Where(x=> !string.IsNullOrEmpty(x)).Select(y => int.Parse(y)).ToList(),
            };
        });
        
        var scores = cards.ToList().Select(x => x.CardNumbers.Intersect(x.WinningNumbers)).Select(x => Score(x));
        return scores.Sum();
    }

    private static int Score(IEnumerable<int> enumerable)
    {
        if (enumerable.Count() == 0)
            return 0;
        var counter = 1;
        foreach (var score in enumerable.Skip(1))
        {
            counter = counter * 2;
        }

        return counter;
    }
}

public class Card
{
    public int Id { get; set; }
    public List<int> WinningNumbers { get; set; }
    public List<int> CardNumbers { get; set; }
}