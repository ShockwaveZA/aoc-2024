using aoc_2024.Util;

namespace aoc_2024.Models;

public class Day2(int day) : Solution(day)
{
    private static string[] ValuesWithoutIndex(string[] values, int index)
    {
        var filtered = new string[values.Length - 1];
        var i = 0;
        for (var j = 0; j < values.Length; j++)
        {
            if (j == index) continue;
            filtered[i++] = values[j];
        }

        return filtered;
    }

    private bool RetryValidateReport(string[] values)
    {
        for (var i = 0; i < values.Length; i++)
        {
            var filteredValues = ValuesWithoutIndex(values, i);
            if (ValidReport(filteredValues))
            {
                return true;
            }
        }

        return false;
    }
    
    private bool ValidReport(string[] values, bool dampener = false)
    {
        var lastDifference = 0;
        for (var i = 0; i < values.Length - 1; i++)
        {
            var current = int.Parse(values[i]);
            var next = int.Parse(values[i + 1]);
                
            var difference = next - current;
                
            // Check if rate of change too high
            if (Math.Abs(difference) > 3)
            {
                if (!dampener) return false;
                if (!RetryValidateReport(values)) return false;
            }

            // Check if differences change direction
            if (difference == 0)
            {
                // A change of 0 is invalid
                if (!dampener) return false;
                if (!RetryValidateReport(values)) return false;
            }

            if (lastDifference == 0 || difference * lastDifference > 0)
            {
                lastDifference = difference;
                continue;
            }
            if (!dampener) return false;
            if (!RetryValidateReport(values)) return false;
        }

        return true;
    }

    public override int ComputePart1()
    {
        var lines = InputReader.ReadInput(Day);

        var validCount = 0;
        foreach (var report in lines)
        {
            var values = report.Split(" ");
            if (ValidReport(values))
            {
                validCount++;
            }
        }
        
        return validCount;
    }

    public override int ComputePart2()
    {
        var lines = InputReader.ReadInput(Day);

        var validCount = 0;
        foreach (var report in lines)
        {
            var values = report.Split(" ");

            if (ValidReport(values, true))
            {
                validCount++;
            }
        }
        
        return validCount;
    }
}