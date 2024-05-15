namespace LabAPI.Models.Domain
{
    public class Book_Author
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int AuthorID { get; set; } // Thêm khóa ngoại đến bảng Authors
        public Book Book { get; set; }
        public Author Author { get; set; } // Thêm thuộc tính Author
    }
}
    