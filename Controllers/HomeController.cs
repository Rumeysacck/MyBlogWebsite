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
        // You can add authorization logic here if needed.
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
        // Ortam değişkenlerinden admin email ve şifresini alıyoruz
        var adminEmail = Environment.GetEnvironmentVariable("ADMIN_EMAIL");
        var adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");

        // Kullanıcıdan alınan email ve şifre ortam değişkenlerindeki değerlerle eşleşiyorsa
        if (email == adminEmail && password == adminPassword)
        {
            // Giriş başarılı, admin paneline yönlendir
            return RedirectToAction("AdminPanel");
        }

        // Giriş başarısızsa, hata mesajı döndür
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

