﻿using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using MyBlogWebsite.Models;

namespace MyWebsite.Controllers;

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

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Blogs()
    {
        return View();
    }
    public IActionResult AdminPanel()
    {
        // You can add authorization logic here if needed.
           return View();
    }
    public IActionResult Login()
    {
        return View(); // Ensure that you have a Login.cshtml view file.
    }

    public IActionResult Portfolio()
    {
        return View();
    }


    public IActionResult Contact()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }










}

