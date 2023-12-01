using NUnit.Framework;

namespace Tests;

public class DayDayNumberTests
{
    [Test]
    public void SamplePartDayNumber()
    {
        var sample = @"";
        var result = DayDayNumberService.Run(sample);
        Assert.That(result, Is.EqualTo(142));
    }
    [Test]
    public async Task RealPartDayNumber()
    {
        var str = await AdventOfCodeHelpers.GetLinesFromInput(DayNumber);
        var output = DayDayNumberService.Run(str);
        Assert.That(output, Is.EqualTo(54634));
    }
    
}