using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

public class MembersController : BaseController
{
    private readonly LibraryContext _context;
    public MembersController(LibraryContext context) => _context = context;

    public async Task<IActionResult> Index() => View(await _context.Members.OrderBy(m => m.FullName).ToListAsync());
    public IActionResult Create() => View(new Member());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Member member)
    {
        if (!ModelState.IsValid) return View(member);
        _context.Add(member);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var member = await _context.Members.FindAsync(id);
        return member == null ? NotFound() : View(member);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Member member)
    {
        if (id != member.MemberId) return NotFound();
        if (!ModelState.IsValid) return View(member);
        _context.Update(member);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var member = await _context.Members.FindAsync(id);
        return member == null ? NotFound() : View(member);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member != null)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
