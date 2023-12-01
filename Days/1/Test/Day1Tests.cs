using Days._1.Src;
using Days.Helpers;

namespace Days._1.Test;

public class Day1Tests
{
    [Test]
    public void SamplePart1()
    {
        var str = @"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet
";
        var output = Parser.Parse(str);
        Assert.That(output, Is.EqualTo(142));
    }
    //[Test]
    public async Task RealPart1()
    {
        var str = await AdventOfCodeHelpers.GetLinesFromInput(1);
        var output = Parser.Parse(str);
        Assert.That(output, Is.EqualTo(54634));
    }
    
    [Test]
    public void SamplePart2()
    {
        var str = @"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen
";
        var output = Parser.Parse(str);
        Assert.That(output, Is.EqualTo(281));
    }
    [Test]
    public async Task RealPart2()
    {
        var str = await AdventOfCodeHelpers.GetLinesFromInput(1);
        var output = Parser.Parse(str);
        Assert.That(output, Is.EqualTo(53855));
    }

    [TestCase("eightwothree", 8)]
    [TestCase("abcone2threexyz", 1)]
    [TestCase("4nineeightseven2", 4)]
    public void ParseFirstNumber(string input, int expectedOutput)
    {
        var result = Parser.MakeNumberList(input).First();
        Assert.That(result, Is.EqualTo(expectedOutput));
    }
    
    [TestCase("eightwothree", 3)]
    [TestCase("abcone2threexyz", 3)]
    [TestCase("4nineeightseven2", 2)]
    public void ParseLastNumber(string input, int expectedOutput)
    {
        var result = Parser.MakeNumberList(input).Last();
        Assert.That(result, Is.EqualTo(expectedOutput));
    }
    
    [TestCase("qlxvsixonehbdfsxvhsevenzqcdrvk421",61)]
    [TestCase("27six2sixjqctbbfv5",25)]
    [TestCase("6fiveeighttwo",62)]
    [TestCase("mcclrxlpqhvhkptbsrrrsgbdzq6one",61)]
    [TestCase("9fiveghrrhtqnmhtwoonenine",99)]
    [TestCase("sbzvmddhnjtwollnjv33d2lbcscstqt",22)]
    [TestCase("3tgsppcfpk", 33)]
    [TestCase("52", 52)]
    [TestCase("2crb2", 22)]
    [TestCase("1mjmxsvnb3eight", 18)]
    [TestCase("eight517feightmxl8", 88)]
    [TestCase("one1threeeight76rcmkskpvmrz", 16)]
    [TestCase("onethreecqnczs8tdfiveeightthree", 13)]
    [TestCase("fourtwo15nine1", 41)]
    [TestCase("1rxfour4xjzdfgqsixmjvvzfnh6m", 16)]
    [TestCase("zvcfive2eight5hghsix19", 59)]
    [TestCase("3nxlmh448two899", 39)]
    [TestCase("three98oneightzn", 38)]
    [TestCase("3fourtwozszhmcp", 32)]
    [TestCase("twopvhd73", 23)]
    [TestCase("oneqdlsb7sixllszjbceight", 18)]
    [TestCase("xmqxqsixpgclxldnvlzvjm7nine4", 64)]
    [TestCase("fourfive4tttldbmmkxvhqrmvmrkpxfzbd7", 47)]
    [TestCase("44two1", 41)]
    [TestCase("eightrtsjszc2", 82)]
    public void Edgecase(string input, int number)
    {
        var str = input;
        var output = Parser.Parse(str);
        Assert.That(output, Is.EqualTo(number));
    }
}