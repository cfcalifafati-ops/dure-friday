using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models;

public class AppUser
{
    public int AppUserId { get; set; }

    [Required, StringLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Password { get; set; } = string.Empty;

    [Required, StringLength(20)]
    public string Role { get; set; } = "Librarian";
}
