using Microsoft.AspNetCore.Mvc;
using YourProjectNamespace.Models.Db;
using YourProjectNamespace.Data;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBlogRepository _repo;

    
    public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    
    public async Task<IActionResult> Index()
    {
        var newUser = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = "Andrey",
            LastName = "Petrov",
            JoinDate = DateTime.Now
        };

        await _repo.AddUser(newUser); 

        
        Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");

        return View(); 
    }
}
