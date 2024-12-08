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
        ISolution solution = new Day1();
        switch (day)
        {
            case 1:
                solution = new Day1();
                break;
            default:
                solution = new Day1();
                break;
        }
        
        
        ViewData["Title"] = "Day - " + day;
        ViewData["Day"] = day;
        ViewData["Part1Result"] = solution.ComputePart1(day);
        ViewData["Part2Result"] = solution.ComputePart2(day);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}