using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

public class BorrowRecordsController : BaseController
{
    private readonly LibraryContext _context;
    public BorrowRecordsController(LibraryContext context) => _context = context;

    public async Task<IActionResult> Index()
    {
        var records = _context.BorrowRecords.Include(b => b.Book).Include(b => b.Member).OrderByDescending(b => b.BorrowDate);
        return View(await records.ToListAsync());
    }

    public IActionResult Create()
    {
        LoadDropDowns();
        return View(new BorrowRecord());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BorrowRecord record)
    {
        if (!ModelState.IsValid)
        {
            LoadDropDowns();
            return View(record);
        }
        var book = await _context.Books.FindAsync(record.BookId);
        if (book == null || book.Quantity <= 0)
        {
            ModelState.AddModelError("BookId", "Book is not available.");
            LoadDropDowns();
            return View(record);
        }
        book.Quantity -= 1;
        record.Status = "Borrowed";
        _context.BorrowRecords.Add(record);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> ReturnBook(int id)
    {
        var record = await _context.BorrowRecords.Include(r => r.Book).FirstOrDefaultAsync(r => r.BorrowRecordId == id);
        if (record == null) return NotFound();
        record.ReturnDate = DateTime.Today;
        record.Status = "Returned";
        if (record.Book != null) record.Book.Quantity += 1;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var record = await _context.BorrowRecords.Include(r => r.Book).Include(r => r.Member).FirstOrDefaultAsync(r => r.BorrowRecordId == id);
        return record == null ? NotFound() : View(record);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var record = await _context.BorrowRecords.FindAsync(id);
        if (record != null)
        {
            _context.BorrowRecords.Remove(record);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private void LoadDropDowns()
    {
        ViewData["BookId"] = new SelectList(_context.Books.OrderBy(b => b.Title), "BookId", "Title");
        ViewData["MemberId"] = new SelectList(_context.Members.OrderBy(m => m.FullName), "MemberId", "FullName");
    }
}
