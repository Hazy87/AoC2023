using Days.Helpers;
using NUnit.Framework;

namespace Tests;

public class Day3Tests
{
    [Test]
    public void SamplePart3()
    {
        var sample = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";
        var result = Day3Service.Run(sample.Split("\n").Where(x => !string.IsNullOrEmpty(x)));
        Assert.That(result, Is.EqualTo(467835));
    }
    [Test]
    public void SamplePart3_Edge()
    {
        var sample = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.664..";
        var result = Day3Service.Run(sample.Split("\n").Where(x => !string.IsNullOrEmpty(x)));
        Assert.That(result, Is.EqualTo(4427));
    }
    
    
    [Test]
    public async Task RealPart3()
    {
        var str = await FileHelpers.GetLinesFromInputAsLines(3);;
        var output = Day3Service.Run(str);
        Assert.That(output, Is.EqualTo(54634));
    }
    
}