using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class Member
{
    public int MemberId { get; set; }

    [Required, StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required, Phone, StringLength(20)]
    public string Phone { get; set; } = string.Empty;

    public DateTime DateJoined { get; set; } = DateTime.Now;

    public ICollection<BorrowRecord>? BorrowRecords { get; set; }
}
