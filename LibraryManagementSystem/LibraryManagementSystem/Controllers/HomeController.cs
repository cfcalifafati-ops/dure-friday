using LibraryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers;

public class HomeController : BaseController
{
    private readonly LibraryContext _context;
    public HomeController(LibraryContext context) => _context = context;

    public IActionResult Index()
    {
        ViewBag.TotalBooks = _context.Books.Count();
        ViewBag.TotalMembers = _context.Members.Count();
        ViewBag.BorrowedBooks = _context.BorrowRecords.Count(b => b.Status == "Borrowed");
        ViewBag.OverdueBooks = _context.BorrowRecords.Count(b => b.Status == "Borrowed" && b.DueDate < DateTime.Today);
        return View();
    }
}
