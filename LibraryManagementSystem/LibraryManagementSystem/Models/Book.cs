using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class Book
{
    public int BookId { get; set; }

    [Required, StringLength(120)]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Author { get; set; } = string.Empty;

    [Required, StringLength(30)]
    public string ISBN { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Category { get; set; } = string.Empty;

    [Range(0, 1000)]
    public int Quantity { get; set; }

    [StringLength(200)]
    public string? CoverImageUrl { get; set; }

    public ICollection<BorrowRecord>? BorrowRecords { get; set; }
}
