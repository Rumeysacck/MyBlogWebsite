using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using MyBlogWebsite.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace MyWebsite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient;

    

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
         _httpClient = new HttpClient();
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public async Task<IActionResult> Blogs()
    {
        string firebaseUrl = "https://myblog-f187d-default-rtdb.europe-west1.firebasedatabase.app/blogs.json";

        try
        {
            // Fetch blogs from Firebase Realtime Database
            HttpResponseMessage response = await _httpClient.GetAsync(firebaseUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonData = await response.Content.ReadAsStringAsync();
                
                // Parse the JSON data into a JArray (using Newtonsoft.Json)
                var blogs = JObject.Parse(jsonData);

                // Pass the blog data to the view
                return View(blogs);
            }
            else
            {
                // If request fails, log error and return empty view
                _logger.LogError($"Failed to fetch blogs: {response.ReasonPhrase}");
                return View(new JObject());
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error fetching blogs from Firebase: {ex.Message}");
            return View(new JObject());
        }
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

    
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        
    var adminEmail = Environment.GetEnvironmentVariable("ADMIN_EMAIL");
    var adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");

    
    _logger.LogInformation($"Admin Email: {adminEmail}, Admin Password: {adminPassword}");

    
    if (email == adminEmail && password == adminPassword)
    {
        
        HttpContext.Session.SetString("isAdmin", "true");
        return RedirectToAction("AdminPanel");
    }

    
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

