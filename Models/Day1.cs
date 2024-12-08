using aoc_2024.Util;

namespace aoc_2024.Models;

public class Day1: ISolution
{


    public int ComputePart1(int day)
    {
        var lines = InputReader.ReadInput(day);
        
        var leftNumbers = new List<int>();
        var rightNumbers = new List<int>();
        foreach (var line in lines)
        {
            var parts = line.Split(" ");
            leftNumbers.Add(int.Parse(parts[0]));
            rightNumbers.Add(int.Parse(parts[^1]));
        }
        leftNumbers.Sort();
        rightNumbers.Sort();

        var total = 0;
        while (leftNumbers.Count != 0 && rightNumbers.Count != 0)
        {
            total += Math.Abs(rightNumbers[0] - leftNumbers[0]);
            leftNumbers.RemoveAt(0);
            rightNumbers.RemoveAt(0);
        }
        
        return total;
    }

    public int ComputePart2(int day)
    {
        var lines = InputReader.ReadInput(day);
        
        var leftNumbers = new List<int>();
        var rightNumbers = new List<int>();
        foreach (var line in lines)
        {
            var parts = line.Split(" ");
            leftNumbers.Add(int.Parse(parts[0]));
            rightNumbers.Add(int.Parse(parts[^1]));
        }

        var total = 0;
        foreach (var leftNumber in leftNumbers)
        {
            var count = rightNumbers.Count(n => n == leftNumber);
            total += leftNumber * count;
        }
        
        return total;
    }
}