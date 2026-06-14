using Microsoft.Data.SqlClient;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public class BookRepository
    {
        private readonly string _connectionString;

        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Get all books
        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = @"
                SELECT b.BookID, b.Title, b.ISBN, b.PublishedYear, 
                       b.Quantity, a.AuthorName, c.CategoryName
                FROM Books b
                INNER JOIN Authors    a ON b.AuthorID   = a.AuthorID
                INNER JOIN Categories c ON b.CategoryID = c.CategoryID";

            using var cmd = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                books.Add(new Book
                {
                    BookID        = (int)reader["BookID"],
                    Title         = reader["Title"].ToString(),
                    ISBN          = reader["ISBN"].ToString(),
                    PublishedYear = (int)reader["PublishedYear"],
                    Quantity      = (int)reader["Quantity"],
                    AuthorName    = reader["AuthorName"].ToString(),
                    CategoryName  = reader["CategoryName"].ToString()
                });
            }
            return books;
        }

        // Add book via stored procedure
        public void AddBook(Book book)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("sp_AddBook", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title",      book.Title);
            cmd.Parameters.AddWithValue("@ISBN",       book.ISBN);
            cmd.Parameters.AddWithValue("@Year",       book.PublishedYear);
            cmd.Parameters.AddWithValue("@Quantity",   book.Quantity);
            cmd.Parameters.AddWithValue("@CategoryID", book.CategoryID);
            cmd.Parameters.AddWithValue("@AuthorID",   book.AuthorID);
            cmd.ExecuteNonQuery();
        }

        // Search book by title
        public List<Book> SearchByTitle(string title)
        {
            var books = new List<Book>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = @"
                SELECT b.BookID, b.Title, b.ISBN, b.PublishedYear,
                       b.Quantity, a.AuthorName, c.CategoryName
                FROM Books b
                INNER JOIN Authors    a ON b.AuthorID   = a.AuthorID
                INNER JOIN Categories c ON b.CategoryID = c.CategoryID
                WHERE b.Title LIKE @Title";

            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Title", "%" + title + "%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                books.Add(new Book
                {
                    BookID        = (int)reader["BookID"],
                    Title         = reader["Title"].ToString(),
                    ISBN          = reader["ISBN"].ToString(),
                    PublishedYear = (int)reader["PublishedYear"],
                    Quantity      = (int)reader["Quantity"],
                    AuthorName    = reader["AuthorName"].ToString(),
                    CategoryName  = reader["CategoryName"].ToString()
                });
            }
            return books;
        }

        // Delete book
        public void DeleteBook(int bookId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("DELETE FROM Books WHERE BookID = @BookID", conn);
            cmd.Parameters.AddWithValue("@BookID", bookId);
            cmd.ExecuteNonQuery();
        }
    }
}