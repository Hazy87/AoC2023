namespace Days.Helpers;

public static class FileHelpers
{
    private static string _directoryPathTemplate = "Inputs/{0}";
    private static string _pathTemplate = "{0}/input.txt";
    private static string _session = File.ReadAllText("Helpers/session");


    public static async Task LoadInput(int day)
    {
        
        var (directoryPath, filePath) = MakePaths(day);
        if (File.Exists(filePath))
            return;
        Directory.CreateDirectory(directoryPath);
        var stream = await $"https://adventofcode.com/2023/day/{day}/input".WithCookie("session",
                _session)
            .GetStreamAsync();
        await using var fileStream = new FileStream(filePath, FileMode.CreateNew);
        await stream.CopyToAsync(fileStream);
    }

    public static async Task<string> GetLinesFromInput(int day)
    {
        await LoadInput(day);
        var (_, filePath) = MakePaths(day);
        return await File.ReadAllTextAsync(filePath);
    }
    
    public static async Task<IEnumerable<string>> GetLinesFromInputAsLines(int day)
    {
        return (await GetLinesFromInput(day)).Split("\n").Where(x => !string.IsNullOrEmpty(x));
        
    }

    private static (string directoryPath, string filePath) MakePaths(int day)
    {
        var directoryPath = string.Format(_directoryPathTemplate, day);
        var path = string.Format(_pathTemplate, directoryPath);
        return (directoryPath,path);
    }
}

public static class StringExtensions
{
    public static string[] NewLineSplit(this string str, bool part2 = true)
    {
        return str.Split("\n");
    }
}