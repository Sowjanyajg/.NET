using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;

namespace LibraryManagementSystem.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepo;

        public BookService(string connectionString)
        {
            _bookRepo = new BookRepository(connectionString);
        }

        public void AddBook()
        {
            try
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(title))
                    throw new Exception("Title cannot be empty.");

                Console.Write("Enter ISBN: ");
                string isbn = Console.ReadLine()!;

                Console.Write("Enter Published Year: ");
                int year = int.Parse(Console.ReadLine()!);

                Console.Write("Enter Quantity: ");
                int qty = int.Parse(Console.ReadLine()!);
                if (qty < 0)
                    throw new Exception("Quantity cannot be negative.");

                Console.Write("Enter Category ID: ");
                int categoryId = int.Parse(Console.ReadLine()!);

                Console.Write("Enter Author ID: ");
                int authorId = int.Parse(Console.ReadLine()!);

                var book = new Book
                {
                    Title         = title,
                    ISBN          = isbn,
                    PublishedYear = year,
                    Quantity      = qty,
                    CategoryID    = categoryId,
                    AuthorID      = authorId
                };

                _bookRepo.AddBook(book);
                Console.WriteLine("\n Book added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
        }

        public void ViewAllBooks()
        {
            try
            {
                var books = _bookRepo.GetAllBooks();
                if (books.Count == 0)
                {
                    Console.WriteLine("No books found.");
                    return;
                }

                Console.WriteLine("\n================================================");
                Console.WriteLine(" ID  | Title                | Author         | Category");
                Console.WriteLine("================================================");
                foreach (var b in books)
                {
                    Console.WriteLine($" {b.BookID,-4}| {b.Title,-22}| {b.AuthorName,-15}| {b.CategoryName}");
                }
                Console.WriteLine("================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
        }

        public void SearchBook()
        {
            try
            {
                Console.Write("Enter book title to search: ");
                string title = Console.ReadLine()!;
                var books = _bookRepo.SearchByTitle(title);

                if (books.Count == 0)
                {
                    Console.WriteLine("No books found.");
                    return;
                }

                Console.WriteLine("\n================================================");
                Console.WriteLine(" ID  | Title                | Author         | Qty");
                Console.WriteLine("================================================");
                foreach (var b in books)
                {
                    Console.WriteLine($" {b.BookID,-4}| {b.Title,-22}| {b.AuthorName,-15}| {b.Quantity}");
                }
                Console.WriteLine("================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
        }

        public void DeleteBook()
        {
            try
            {
                ViewAllBooks();
                Console.Write("\nEnter Book ID to delete: ");
                int id = int.Parse(Console.ReadLine()!);
                _bookRepo.DeleteBook(id);
                Console.WriteLine("\n Book deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
        }
    }
}