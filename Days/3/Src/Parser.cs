using Days.Helpers;

public class Day3Service
{
    public static int Run(IEnumerable<string> str)
    {
        var list = str.ToList();
        var makeArray = MakeArray(list);

        return makeArray;
    }

    
    private static int MakeArray(List<string> list)
    {
        var engineParts = new List<int>();
        for (int i = 0; i < list.Count - 1; i++)
        {
            
            var gearRatios = new List<int>();
            for (int j = 0; j < list[i].Length; j++)
            {
                var myChar = list[i][j];
                if (myChar != '*')
                    continue;
                var upPart = GetEngineParts(list, i + 1, j);
                gearRatios.Add(upPart);
                var downPart = GetEngineParts(list, i - 1, j);
                gearRatios.Add(downPart);
                gearRatios.Add(GetEngineParts(list, i, j + 1));
                gearRatios.Add(GetEngineParts(list, i, j - 1));

                if (upPart == 0)
                {
                    gearRatios.Add(GetEngineParts(list, i + 1, j + 1));
                    gearRatios.Add(GetEngineParts(list, i + 1, j - 1));
                }

                if (downPart == 0)
                {
                    gearRatios.Add(GetEngineParts(list, i - 1, j + 1));
                    gearRatios.Add(GetEngineParts(list, i - 1, j - 1));
                }   
            }
            if(gearRatios.Where(x => x != 0).Count() == 2)
                engineParts.Add(gearRatios.Where(x => x != 0).Aggregate(1, (x,y) => x * y));    
        }

        return engineParts.Sum();
    }
    
    private static int GetEngineParts(List<string> list, int newX, int newY)
    {
        if (!OutOfBoundsCheck(list, newX, newY)) return 0;
        if (newX < 0 || !Char.IsNumber(list[newX][newY]) )
            return 0;
        return GetFullNumber(list, newX, newY);
    }

    private static bool OutOfBoundsCheck(List<string> list, int newX, int newY)
    {
        if (newX < 0 || newX > list.Count - 1 || newY < 0 || newY > list[0].Length - 1) return false;
        return true;
    }

    private static int GetFullNumber(List<string> list, int x, int y)
    {
        var start = y;
        bool searching = true;
        while (searching)
        {
            if (start > 0 && Char.IsNumber(list[x][start - 1]))
                start = start - 1;
            else
                searching = false;
        }
        var end = y;
        searching = true;
        while (searching)
        {
            if (end < list[x].Length-1 && Char.IsNumber(list[x][end + 1]))
                end = end + 1;
            else
                searching = false;
        }

        return int.Parse(list[x].Substring(start, end-start+1));
    }
}