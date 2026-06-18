using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class BorrowRecord
{
    public int BorrowRecordId { get; set; }

    [Required]
    public int BookId { get; set; }
    public Book? Book { get; set; }

    [Required]
    public int MemberId { get; set; }
    public Member? Member { get; set; }

    [DataType(DataType.Date)]
    public DateTime BorrowDate { get; set; } = DateTime.Today;

    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; } = DateTime.Today.AddDays(14);

    [DataType(DataType.Date)]
    public DateTime? ReturnDate { get; set; }

    [Required, StringLength(20)]
    public string Status { get; set; } = "Borrowed";
}
