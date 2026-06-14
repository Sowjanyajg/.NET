using LibraryManagementSystem.Repository;

namespace LibraryManagementSystem.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _transRepo;

        public TransactionService(string connectionString)
        {
            _transRepo = new TransactionRepository(connectionString);
        }

        public void IssueBook()
        {
            try
            {
                Console.Write("Enter Book ID: ");
                int bookId = int.Parse(Console.ReadLine()!);

                Console.Write("Enter Member ID: ");
                int memberId = int.Parse(Console.ReadLine()!);

                _transRepo.IssueBook(bookId, memberId);
                Console.WriteLine("\n Book issued successfully! Due in 14 days.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
        }

        public void ReturnBook()
        {
            try
            {
                ViewIssuedBooks();
                Console.Write("\nEnter Transaction ID to return: ");
                int transId = int.Parse(Console.ReadLine()!);

                _transRepo.ReturnBook(transId);
                Console.WriteLine("\n Book returned successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
        }

        public void ViewIssuedBooks()
        {
            try
            {
                var list = _transRepo.GetIssuedBooks();
                if (list.Count == 0)
                {
                    Console.WriteLine("No issued books found.");
                    return;
                }

                Console.WriteLine("\n================================================");
                Console.WriteLine(" TID | Book Title           | Member          | Due Date   | Status");
                Console.WriteLine("================================================");
                foreach (var t in list)
                {
                    Console.WriteLine($" {t.TransactionID,-4}| {t.BookTitle,-22}| {t.MemberName,-16}| {t.DueDate:yyyy-MM-dd} | {t.Status}");
                }
                Console.WriteLine("================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
        }
    }
}