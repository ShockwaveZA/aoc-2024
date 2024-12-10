namespace aoc_2024.Models;

public abstract class Solution(int day)
{
    protected int Day = day;

    public abstract int ComputePart1();
    public abstract int ComputePart2();
}