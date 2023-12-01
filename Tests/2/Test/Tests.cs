using NUnit.Framework;

namespace Tests;

public class Day2Tests
{
    [Test]
    public void SamplePart2()
    {
        var sample = @"";
        var result = Day2Service.Run(sample);
        Assert.That(result, Is.EqualTo(142));
    }
    [Test]
    public async Task RealPart2()
    {
        var str = await AdventOfCodeHelpers.GetLinesFromInput(2);
        var output = Day2Service.Run(str);
        Assert.That(output, Is.EqualTo(54634));
    }
    
}