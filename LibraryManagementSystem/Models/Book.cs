namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int     BookID        { get; set; }
        public string? Title         { get; set; }
        public string? ISBN          { get; set; }
        public int     PublishedYear { get; set; }
        public int     Quantity      { get; set; }
        public int     CategoryID    { get; set; }
        public int     AuthorID      { get; set; }
        public string? AuthorName    { get; set; }
        public string? CategoryName  { get; set; }
    }
}