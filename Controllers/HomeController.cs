using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aoc_2024.Models;

namespace aoc_2024.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Day(int day)
    {
        Solution solution = day switch
        {
            1 => new Day1(day),
            2 => new Day2(day),
            3 => new Day3(day),
            4 => new Day4(day),
            5 => new Day5(day),
            
            _ => new Day1(day)
        };

        ViewData["Title"] = "Day - " + day;
        ViewData["Day"] = day;
        ViewData["Part1Result"] = solution.ComputePart1();
        ViewData["Part2Result"] = solution.ComputePart2();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}