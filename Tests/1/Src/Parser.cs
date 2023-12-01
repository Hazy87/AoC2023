using System.Runtime.InteropServices.JavaScript;

public class Parser
{
    public static int Parse(string str)
    {
        var lines = str.Split("\n").Where(x => !string.IsNullOrEmpty(x));
        return lines.Sum(x => ProcessLine(x));
    }

    private static int ProcessLine(string line)
    {
        var numberList = MakeNumberList(line);
        var lineNumber = $"{numberList.First()}{numberList.Last()}";
        return int.Parse(lineNumber);
    }

    public static List<int> MakeNumberList(string input)
    {
        var numberList = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            var result = GetNextNumber(input, i);
            if(result != null)
                numberList.Add(result.Value);
        }
        return numberList;
    }

    private static int? GetNextNumber(string input, int startIndex)
    {
        return input.Substring(startIndex).FindNumberStartsWith();
    }
}

public static class StringExtension
{
    private static readonly Dictionary<string,int> Numbers = new()
    {
        {"one",1},
        {"two",2},
        {"three",3},
        {"four",4},
        {"five", 5},
        {"six",6},
        {"seven",7} ,
        {"eight",8},
        {"nine",9}
    };
    public static int? FindNumberStartsWith(this string str, bool part2 = true)
    {
        if (char.IsNumber(str[0]))
            return int.Parse(str[0].ToString());
        if (!part2) return null;
        var key = Numbers.Keys.FirstOrDefault(str.StartsWith);
        return key != null ? Numbers[key] : null ;
    }
}