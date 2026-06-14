using Microsoft.Data.SqlClient;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem
{
    internal class Program
    {
        public static readonly string ConnectionString =
            "Server=BOOK-DH1J4U3JJJ\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";

        static BookService        _bookService        = new BookService(ConnectionString);
        static MemberService      _memberService      = new MemberService(ConnectionString);
        static TransactionService _transactionService = new TransactionService(ConnectionString);

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("     LIBRARY MANAGEMENT        ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Book Management");
                Console.WriteLine("2. Member Management");
                Console.WriteLine("3. Issue Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Search Book");
                Console.WriteLine("6. View Issued Books");
                Console.WriteLine("7. Reports");
                Console.WriteLine("8. Exit");
                Console.WriteLine("================================");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1": BookMenu();        break;
                    case "2": MemberMenu();      break;
                    case "3": IssueBook();       break;
                    case "4": ReturnBook();      break;
                    case "5": SearchBook();      break;
                    case "6": ViewIssuedBooks(); break;
                    case "7": ReportsMenu();     break;
                    case "8": Exit();            return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // ── Book Menu ──────────────────────────────────
        static void BookMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("       BOOK MANAGEMENT         ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Back to Main Menu");
                Console.WriteLine("================================");
                Console.Write("Enter choice: ");

                switch (Console.ReadLine())
                {
                    case "1": _bookService.AddBook();      Pause(); break;
                    case "2": _bookService.ViewAllBooks(); Pause(); break;
                    case "3": _bookService.SearchBook();   Pause(); break;
                    case "4": _bookService.DeleteBook();   Pause(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }
        }

        // ── Member Menu ────────────────────────────────
        static void MemberMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("      MEMBER MANAGEMENT        ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. View All Members");
                Console.WriteLine("3. Delete Member");
                Console.WriteLine("4. Back to Main Menu");
                Console.WriteLine("================================");
                Console.Write("Enter choice: ");

                switch (Console.ReadLine())
                {
                    case "1": _memberService.AddMember();      Pause(); break;
                    case "2": _memberService.ViewAllMembers(); Pause(); break;
                    case "3": _memberService.DeleteMember();   Pause(); break;
                    case "4": return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }
        }

        // ── Direct Actions ─────────────────────────────
        static void IssueBook()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("         ISSUE BOOK            ");
            Console.WriteLine("================================");
            _bookService.ViewAllBooks();
            _memberService.ViewAllMembers();
            _transactionService.IssueBook();
            Pause();
        }

        static void ReturnBook()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("         RETURN BOOK           ");
            Console.WriteLine("================================");
            _transactionService.ReturnBook();
            Pause();
        }

        static void SearchBook()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("         SEARCH BOOK           ");
            Console.WriteLine("================================");
            _bookService.SearchBook();
            Pause();
        }

        static void ViewIssuedBooks()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("       ISSUED BOOKS            ");
            Console.WriteLine("================================");
            _transactionService.ViewIssuedBooks();
            Pause();
        }

        // ── Reports Menu ───────────────────────────────
        static void ReportsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("           REPORTS             ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Total Books");
                Console.WriteLine("2. Total Members");
                Console.WriteLine("3. Available Books");
                Console.WriteLine("4. Issued Books");
                Console.WriteLine("5. Overdue Books");
                Console.WriteLine("6. Most Borrowed Books");
                Console.WriteLine("7. Back to Main Menu");
                Console.WriteLine("================================");
                Console.Write("Enter choice: ");

                switch (Console.ReadLine())
                {
                    case "1": Report_TotalBooks();       Pause(); break;
                    case "2": Report_TotalMembers();     Pause(); break;
                    case "3": Report_AvailableBooks();   Pause(); break;
                    case "4": Report_IssuedBooks();      Pause(); break;
                    case "5": Report_OverdueBooks();     Pause(); break;
                    case "6": Report_MostBorrowed();     Pause(); break;
                    case "7": return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }
        }

        // ── Report Methods ─────────────────────────────
        static void Report_TotalBooks()
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Books", conn);
            Console.WriteLine($"\n Total Books: {cmd.ExecuteScalar()}");
        }

        static void Report_TotalMembers()
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();
            var cmd = new SqlCommand("SELECT COUNT(*) FROM Members", conn);
            Console.WriteLine($"\n Total Members: {cmd.ExecuteScalar()}");
        }

        static void Report_AvailableBooks()
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();
            var cmd    = new SqlCommand("SELECT BookID, Title, Quantity FROM Books WHERE Quantity > 0", conn);
            var reader = cmd.ExecuteReader();
            Console.WriteLine("\n================================================");
            Console.WriteLine(" ID  | Title                        | Quantity");
            Console.WriteLine("================================================");
            while (reader.Read())
                Console.WriteLine($" {reader["BookID"],-4}| {reader["Title"],-30}| {reader["Quantity"]}");
            Console.WriteLine("================================================");
        }

        static void Report_IssuedBooks()
        {
            _transactionService.ViewIssuedBooks();
        }

        static void Report_OverdueBooks()
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = @"
                SELECT t.TransactionID, b.Title, m.MemberName, t.DueDate
                FROM Transactions t
                INNER JOIN Books   b ON t.BookID   = b.BookID
                INNER JOIN Members m ON t.MemberID = m.MemberID
                WHERE t.Status = 'Overdue' OR 
                      (t.ReturnDate IS NULL AND t.DueDate < GETDATE())";
            var cmd    = new SqlCommand(query, conn);
            var reader = cmd.ExecuteReader();
            Console.WriteLine("\n================================================");
            Console.WriteLine(" TID | Title                | Member          | Due Date");
            Console.WriteLine("================================================");
            while (reader.Read())
                Console.WriteLine($" {reader["TransactionID"],-4}| {reader["Title"],-22}| {reader["MemberName"],-16}| {reader["DueDate"]:yyyy-MM-dd}");
            Console.WriteLine("================================================");
        }

        static void Report_MostBorrowed()
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = @"
                SELECT TOP 5 b.Title, COUNT(*) AS BorrowCount
                FROM Transactions t
                INNER JOIN Books b ON t.BookID = b.BookID
                GROUP BY b.Title
                ORDER BY BorrowCount DESC";
            var cmd    = new SqlCommand(query, conn);
            var reader = cmd.ExecuteReader();
            Console.WriteLine("\n================================================");
            Console.WriteLine(" Title                        | Times Borrowed");
            Console.WriteLine("================================================");
            while (reader.Read())
                Console.WriteLine($" {reader["Title"],-30}| {reader["BorrowCount"]}");
            Console.WriteLine("================================================");
        }

        // ── Helpers ────────────────────────────────────
        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void Exit()
        {
            Console.Clear();
            Console.WriteLine("================================");
            Console.WriteLine("  Thank you for using LMS!");
            Console.WriteLine("================================");
        }
    }
}