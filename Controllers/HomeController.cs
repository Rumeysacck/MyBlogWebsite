using System.Diagnostics;
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
        if (HttpContext.Session.GetString("isAdmin") != "true")
    {
        return RedirectToAction("Login");
    }

    return View();
        
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // Giriş işlemi için POST isteği
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        // Retrieve admin credentials from environment variables
    var adminEmail = Environment.GetEnvironmentVariable("ADMIN_EMAIL");
    var adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");

    // Debugging: Log the retrieved values for confirmation
    _logger.LogInformation($"Admin Email: {adminEmail}, Admin Password: {adminPassword}");

    // Check if the provided email and password match the admin credentials
    if (email == adminEmail && password == adminPassword)
    {
        // Set the session variable to indicate that the user is an admin
        HttpContext.Session.SetString("isAdmin", "true");
        return RedirectToAction("AdminPanel");
    }

    // If the credentials do not match, return an error message
    ViewBag.Error = "Geçersiz kullanıcı adı veya şifre.";
    return View();
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

