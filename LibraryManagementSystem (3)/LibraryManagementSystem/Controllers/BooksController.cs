using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

public class BooksController : BaseController
{
    private readonly LibraryContext _context;
    public BooksController(LibraryContext context) => _context = context;

    public async Task<IActionResult> Index(string? search)
    {
        var books = _context.Books.AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
            books = books.Where(b => b.Title.Contains(search) || b.Author.Contains(search) || b.ISBN.Contains(search));
        ViewBag.Search = search;
        return View(await books.OrderBy(b => b.Title).ToListAsync());
    }

    public IActionResult Create() => View(new Book());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Book book)
    {
        if (!ModelState.IsValid) return View(book);
        _context.Add(book);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var book = await _context.Books.FindAsync(id);
        return book == null ? NotFound() : View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Book book)
    {
        if (id != book.BookId) return NotFound();
        if (!ModelState.IsValid) return View(book);
        _context.Update(book);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
        return book == null ? NotFound() : View(book);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var book = await _context.Books.FindAsync(id);
        return book == null ? NotFound() : View(book);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
