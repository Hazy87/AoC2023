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
                Count = 1,
                Id = int.Parse(idSplit[0].Split(" ").Where(x=> !string.IsNullOrEmpty(x)).ToArray()[1]),
                CardNumbers = numberSplit[1].Split(" ").Where(x=> !string.IsNullOrEmpty(x)).Select(y => int.Parse(y)).ToList(),
                WinningNumbers = numberSplit[0].Split(" ").Where(x=> !string.IsNullOrEmpty(x)).Select(y => int.Parse(y)).ToList(),
            };
        }).ToList();

        cards.ForEach(x =>
        {
            var intetsect = x.CardNumbers.Intersect(x.WinningNumbers).Count();
            for (int i = 0; i < intetsect; i++)
            {
                cards[x.Id + i].Count += x.Count;
            }
        });
        return cards.Select(x => x.Count).Sum();
    }

    private static int Score(IEnumerable<int> enumerable)
    {
        var counter = 0;
        foreach (var score in enumerable)
        {
            counter =+ 1;
        }
        return counter;
    }
}

public class Card
{
    public int Id { get; set; }
    public List<int> WinningNumbers { get; set; }
    public List<int> CardNumbers { get; set; }
    public int Count { get; set; }
}