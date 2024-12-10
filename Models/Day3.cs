using System.Text.RegularExpressions;
using aoc_2024.Util;

namespace aoc_2024.Models;

public partial class Day3(int day) : Solution(day)
{

    public override int ComputePart1()
    {
        var memory = string.Join("\n", InputReader.ReadInput(Day));

        var instructions = InstructionRegex().Matches(memory);
        var total = 0;
        foreach (Match instruction in instructions)
        {
            Console.Out.WriteLine(instruction.Value);
            var product = 1;

            var operands = ValueRegex().Matches(instruction.Value);
            foreach (Match operand in operands)
            {
                product *= int.Parse(operand.Value);
            }
            
            total += product;
        }
        
        
        return total;
    }

    public override int ComputePart2()
    {
        var memory = string.Join("\n", InputReader.ReadInput(day));
        
        var instructions = ExpandedInstructionRegex().Matches(memory);
        var total = 0;
        var active = true;
        foreach (Match instruction in instructions)
        {
            Console.Out.WriteLine(instruction.Value);
            var mul = false;
            switch (instruction.Value)
            {
                case "do()":
                    active = true;
                    break;
                case "don't()":
                    active = false;
                    break;
                default:
                    mul = true;
                    break;
            };

            if (!mul || !active) continue;
            
            var product = 1;

            var operands = ValueRegex().Matches(instruction.Value);
            foreach (Match operand in operands)
            {
                product *= int.Parse(operand.Value);
            }
            
            total += product;
        }
        
        
        return total;
    }

    [GeneratedRegex(@"(mul\(\d+,\d+\))|(do\(\))|(don't\(\))")]
    private static partial Regex ExpandedInstructionRegex();

    [GeneratedRegex(@"mul\(\d+,\d+\)")]
    private static partial Regex InstructionRegex();

    [GeneratedRegex(@"\d+")]
    private static partial Regex ValueRegex();
}