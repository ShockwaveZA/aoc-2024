namespace aoc_2024.Util;

public static class InputReader
{
    public static string[] ReadInput(int day)
    {
        var fileDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Inputs", $"{day}.txt");
        if (!File.Exists(fileDirectory))
        {
            throw new FileNotFoundException("Input file not found", fileDirectory);
        }
        
        return File.ReadAllLines(fileDirectory);
    }
}