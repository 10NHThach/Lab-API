using LabAPI.Models.Domain;
using LabAPI.Models.DTO;
using static System.Reflection.Metadata.BlobBuilder;

namespace LabAPI.Repositories
{
    public interface IBookRepository
    {
        List<BookWithAuthorAndPublisherDTO> GetAllBooks(string? filterOn = null, string?
        filterQuery = null, string? sortBy = null,
         bool isAscending = true, int pageNumber = 1, int pageSize = 1000);
        BookWithAuthorAndPublisherDTO GetBookById(int id);
        AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO);
        AddBookRequestDTO? UpdateBookById(int id, AddBookRequestDTO bookDTO);
        Book? DeleteBookById(int id);
    }
}
