using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repository;

namespace LibraryManagementSystem.Services
{
    public class MemberService
    {
        private readonly MemberRepository _memberRepo;

        public MemberService(string connectionString)
        {
            _memberRepo = new MemberRepository(connectionString);
        }

        public void AddMember()
        {
            try
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception("Name cannot be empty.");

                Console.Write("Enter Email: ");
                string email = Console.ReadLine()!;

                Console.Write("Enter Phone (10 digits): ");
                string phone = Console.ReadLine()!;
                if (phone.Length != 10 || !phone.All(char.IsDigit))
                    throw new Exception("Phone must be exactly 10 digits.");

                Console.Write("Enter Address: ");
                string address = Console.ReadLine()!;

                var member = new Member
                {
                    MemberName = name,
                    Email      = email,
                    Phone      = phone,
                    Address    = address
                };

                _memberRepo.AddMember(member);
                Console.WriteLine("\n Member registered successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
        }

        public void ViewAllMembers()
        {
            try
            {
                var members = _memberRepo.GetAllMembers();
                if (members.Count == 0)
                {
                    Console.WriteLine("No members found.");
                    return;
                }

                Console.WriteLine("\n================================================");
                Console.WriteLine(" ID  | Name              | Email              | Phone");
                Console.WriteLine("================================================");
                foreach (var m in members)
                {
                    Console.WriteLine($" {m.MemberID,-4}| {m.MemberName,-18}| {m.Email,-19}| {m.Phone}");
                }
                Console.WriteLine("================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
        }

        public void DeleteMember()
        {
            try
            {
                ViewAllMembers();
                Console.Write("\nEnter Member ID to delete: ");
                int id = int.Parse(Console.ReadLine()!);
                _memberRepo.DeleteMember(id);
                Console.WriteLine("\n Member deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Error: " + ex.Message);
            }
        }
    }
}