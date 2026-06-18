using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data;

public static class DbInitializer
{
    public static void Seed(LibraryContext context)
    {
        if (!context.AppUsers.Any())
        {
            context.AppUsers.Add(new AppUser { Username = "admin", Password = "admin123", Role = "Admin" });
        }

        if (!context.Books.Any())
        {
            context.Books.AddRange(
                new Book { Title = "C# Programming", Author = "John Smith", ISBN = "978000000001", Category = "Programming", Quantity = 5 },
                new Book { Title = "Database Systems", Author = "Mary Jones", ISBN = "978000000002", Category = "Computing", Quantity = 3 },
                new Book { Title = "Web Development with ASP.NET Core", Author = "David Brown", ISBN = "978000000003", Category = "Web Development", Quantity = 4 }
            );
        }

        if (!context.Members.Any())
        {
            context.Members.AddRange(
                new Member { FullName = "Prince Wisdom", Email = "wisdomifedimma@gmail.com", Phone = "07123456789" },
                new Member { FullName = "Jane Student", Email = "jane.student@example.com", Phone = "07999999999" }
            );
        }

        context.SaveChanges();
    }
}
