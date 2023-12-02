using Days.Helpers;
using NUnit.Framework;

namespace Tests;

public class Day2Tests
{
    [Test]
    public void SamplePart2()
    {
        var sample = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
";
        var result = Day2Service.Run(sample);
        Assert.That(result, Is.EqualTo(8));
    }
    [Test]
    public async Task RealPart2()
    {
        var str = await FileHelpers.GetLinesFromInput(2);
        var output = Day2Service.Run(str);
        Assert.That(output, Is.EqualTo(2416));
    }
    
}