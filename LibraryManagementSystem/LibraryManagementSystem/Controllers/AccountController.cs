using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers;

public class AccountController : Controller
{
    private readonly LibraryContext _context;
    public AccountController(LibraryContext context) => _context = context;

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.AppUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user == null)
        {
            ViewBag.Error = "Invalid username or password.";
            return View();
        }
        HttpContext.Session.SetString("Username", user.Username);
        HttpContext.Session.SetString("Role", user.Role);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
