using aoc_2024.Util;

namespace aoc_2024.Models;

public class Day5: Solution
{
    private Dictionary<string, string> precedesMap;

    private List<string> updates;

    public Day5(int day): base(day)
    {
        Init();
    }

    private void Init()
    {
        precedesMap = new Dictionary<string, string>();
        updates = [];
        
        var lines = InputReader.ReadInput(Day);
        var i = 0;
        while (lines[i] != "")
        {
            var parts = lines[i].Split('|');
            if (precedesMap.ContainsKey(parts[0]))
            {
                precedesMap[parts[0]] += "," + parts[1];
            }
            else precedesMap.Add(parts[0], parts[1]);

            i++;
        }

        i++;
        while (i < lines.Length)
        {
            updates.Add(lines[i]);
            
            i++;
        }
    }

    private bool ValidateUpdate(string update)
    {
        var previousNumbers = new List<string>();
        foreach (var number in update.Split(","))
        {
            if (precedesMap.ContainsKey(number))
            {
                var values = precedesMap[number].Split(",");
                if (values.Any(value => previousNumbers.Contains(value)))
                {
                    return false;
                }
            }
            
            previousNumbers.Add(number);
        }

        return true;
    }

    private string[] ValidateUpdates(bool getValid = true)
    {
        return updates.Where(update => ValidateUpdate(update) == getValid).ToArray();
    }
    
    public override int ComputePart1()
    {
        var validUpdates = ValidateUpdates();
        var total = 0;
        foreach (var update in validUpdates)
        {
            var numbers = update.Split(",");
            total += int.Parse(numbers[numbers.Length / 2]);
        }
        
        return total;
    }

    private int FixOrderAndReturnMiddleNumber(string numbers)
    {
        var numberList = numbers.Split(",").ToList();
        foreach (var number in numbers.Split(","))
        {
            var index = numberList.IndexOf(number);
            var precedingNumbers = (precedesMap.ContainsKey(number) ? precedesMap[number] : "" ).Split(",");
            var validPlacement = true;
            for (var i = 0; i < index; i++)
            {
                if (!precedingNumbers.Contains(numberList[i])) continue;
                
                validPlacement = false;
                break;
            }

            if (validPlacement) continue;

            var earliestPrecedingIndex = numberList.Count;
            for (var i = 0; i < index; i++)
            {
                if (!precedingNumbers.Contains(numberList[i])) continue;
                
                earliestPrecedingIndex = i;
                break;
            }

            numberList.RemoveAt(index);
            numberList.Insert(earliestPrecedingIndex, number);
        }

        numberList.ForEach(number => Console.Write(number + " "));
        Console.WriteLine();
        return int.Parse(numberList[numberList.Count / 2]);
    }

    public override int ComputePart2()
    {
        var invalidUpdates = ValidateUpdates(false);
        var total = invalidUpdates.Sum(FixOrderAndReturnMiddleNumber);
        
        return total;
    }
}