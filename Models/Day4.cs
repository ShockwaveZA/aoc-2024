using aoc_2024.Util;

namespace aoc_2024.Models;

public class Day4: ISolution
{

    private static bool CollectXmas(string[] lines, int y, int x, int modY, int modX)
    {
        const string xmas = "XMAS";
        var currentY = y;
        var currentX = x;
        foreach (var c in xmas)
        {
            try
            {
                if (lines[currentY][currentX] != c) return false;
                currentY += modY;
                currentX += modX;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        return true;
    }

    private static int CountVariations(string[] lines, int y, int x)
    {
        var count = 0;
        for (var i = -1; i <= 1; i++)
        {
            for (var j = -1; j <= 1; j++)
            {
                if (CollectXmas(lines, y, x, i, j)) count++;
            }
        }
        return count;
    }
    
    public int ComputePart1(int day)
    {
        var lines = InputReader.ReadInput(day);

        var count = 0;
        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] == 'X') count += CountVariations(lines, y, x);
            }
        }
        
        return count;
    }

    private static bool IsX(string[] lines, int y, int x)
    {
        try
        {
            return (lines[y - 1][x - 1] == 'M' && lines[y + 1][x + 1] == 'S' ||
                    lines[y - 1][x - 1] == 'S' && lines[y + 1][x + 1] == 'M')
                   && 
                   (lines[y + 1][x - 1] == 'M' && lines[y - 1][x + 1] == 'S' ||
                    lines[y + 1][x - 1] == 'S' && lines[y - 1][x + 1] == 'M');
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }

    public int ComputePart2(int day)
    {
        var lines = InputReader.ReadInput(day);

        var count = 0;
        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] == 'A' && IsX(lines, y, x)) count++;
            }
        }
        
        return count;
    }
}