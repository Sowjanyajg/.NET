using Microsoft.Data.SqlClient;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public class TransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void IssueBook(int bookId, int memberId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("sp_IssueBook", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID",   bookId);
            cmd.Parameters.AddWithValue("@MemberID", memberId);
            cmd.ExecuteNonQuery();
        }

        public void ReturnBook(int transactionId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("sp_ReturnBook", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TransactionID", transactionId);
            cmd.ExecuteNonQuery();
        }

        public List<Transaction> GetIssuedBooks()
        {
            var list = new List<Transaction>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = @"
                SELECT t.TransactionID, t.IssueDate, t.DueDate, t.Status,
                       b.Title AS BookTitle, m.MemberName
                FROM Transactions t
                INNER JOIN Books   b ON t.BookID   = b.BookID
                INNER JOIN Members m ON t.MemberID = m.MemberID
                WHERE t.Status = 'Issued' OR t.Status = 'Overdue'";
            using var cmd    = new SqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Transaction
                {
                    TransactionID = (int)reader["TransactionID"],
                    IssueDate     = (DateTime)reader["IssueDate"],
                    DueDate       = (DateTime)reader["DueDate"],
                    Status        = reader["Status"].ToString(),
                    BookTitle     = reader["BookTitle"].ToString(),
                    MemberName    = reader["MemberName"].ToString()
                });
            }
            return list;
        }
    }
}