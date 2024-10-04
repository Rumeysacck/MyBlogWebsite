using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Session kullanımı için gerekli
using MyBlogWebsite.Models;

namespace MyWebsite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Varsayılan olarak açılan Home/Index
    [HttpGet]
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

    // Giriş formunu göstermek için GET isteği
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
            // Giriş başarılı, session'a bilgiyi yazıyoruz
            HttpContext.Session.SetString("isAdmin", "true");
            return RedirectToAction("AdminPanel");
        }

        // Giriş başarısızsa, hata mesajı döndür
        ViewBag.Error = "Geçersiz kullanıcı adı veya şifre.";
        return View();
    }

    // Admin Paneli
    [HttpGet]
    public IActionResult AdminPanel()
    {
        // Kullanıcı admin mi kontrol ediliyor
        if (HttpContext.Session.GetString("isAdmin") != "true")
        {
            return RedirectToAction("Login");
        }
        
        return View();
    }

    // Kullanıcı çıkış işlemi
    [HttpPost]
    public IActionResult Logout()
    {
        // Session sonlandırılıyor
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
