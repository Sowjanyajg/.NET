using Microsoft.Data.SqlClient;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repository
{
    public class MemberRepository
    {
        private readonly string _connectionString;

        public MemberRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Member> GetAllMembers()
        {
            var members = new List<Member>();
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT * FROM Members", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                members.Add(new Member
                {
                    MemberID   = (int)reader["MemberID"],
                    MemberName = reader["MemberName"].ToString(),
                    Email      = reader["Email"].ToString(),
                    Phone      = reader["Phone"].ToString(),
                    Address    = reader["Address"].ToString()
                });
            }
            return members;
        }

        public void AddMember(Member member)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("sp_AddMember", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MemberName", member.MemberName);
            cmd.Parameters.AddWithValue("@Email",      member.Email);
            cmd.Parameters.AddWithValue("@Phone",      member.Phone);
            cmd.Parameters.AddWithValue("@Address",    member.Address);
            cmd.ExecuteNonQuery();
        }

        public void DeleteMember(int memberId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var cmd = new SqlCommand("DELETE FROM Members WHERE MemberID = @MemberID", conn);
            cmd.Parameters.AddWithValue("@MemberID", memberId);
            cmd.ExecuteNonQuery();
        }
    }
}