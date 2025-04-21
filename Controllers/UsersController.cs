using Microsoft.AspNetCore.Mvc;
using YourProjectNamespace.Data;
using YourProjectNamespace.Models.Db;

public class UsersController : Controller
{
    private readonly IBlogRepository _repo;

    public UsersController(IBlogRepository repo)
    {
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        var authors = await _repo.GetUsers();
        return View(authors); 
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> Register(User newUser)
    {
        newUser.Id = Guid.NewGuid();
        newUser.JoinDate = DateTime.Now;
        await _repo.AddUser(newUser);
        return View(newUser); 
    }
}
