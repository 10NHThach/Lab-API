using Microsoft.EntityFrameworkCore;
using LabAPI.Data;
using LabAPI.Models.Domain;
using LabAPI.Models.DTO;
namespace LabAPI.Repositories
{
    public class SQLBookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;
        public SQLBookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookWithAuthorAndPublisherDTO> GetAllBooks(string? filterOn = null, string?
        filterQuery = null,
         string? sortBy = null, bool isAscending = true, int pageNumber = 1, int
        pageSize = 1000)
        {
            var allBooks = _dbContext.Books.Select(book => new
           BookWithAuthorAndPublisherDTO()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead && book.DateRead != null ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publishers.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList(),
            }).AsQueryable();
            //filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false &&
           string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("title", StringComparison.OrdinalIgnoreCase))
                {
                    allBooks = allBooks.Where(x => x.Title.Contains(filterQuery));
                }
            }
            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("title", StringComparison.OrdinalIgnoreCase))
                {
                    allBooks = isAscending ? allBooks.OrderBy(x => x.Title) :
                   allBooks.OrderByDescending(x => x.Title);
                }
            }
            //pagination
            var skipResults = (pageNumber - 1) * pageSize;
            return allBooks.Skip(skipResults).Take(pageSize).ToList();
        }

        public BookWithAuthorAndPublisherDTO GetBookById(int id)
        {
            var bookWithDomain = _dbContext.Books.Where(n => n.Id == id);
            //Map Domain Model to DTOs
            var bookWithIdDTO = bookWithDomain.Select(book => new
            BookWithAuthorAndPublisherDTO()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publishers.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return bookWithIdDTO;
        }

        public AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO)
        {
            //map DTO to Domain Model
            var bookDomainModel = new Book
            {
                Title = addBookRequestDTO.Title,
                Description = addBookRequestDTO.Description,
                IsRead = addBookRequestDTO.IsRead,
                DateRead = addBookRequestDTO.DateRead,
                Rate = addBookRequestDTO.Rate,
                Genre = addBookRequestDTO.Genre,
                CoverUrl = addBookRequestDTO.CoverUrl,
                DateAdded = addBookRequestDTO.DateAdded,
                PublishersId = addBookRequestDTO.PublisherId
            };
            //Use Domain Model to add Book
            _dbContext.Books.Add(bookDomainModel);
            _dbContext.SaveChanges();
            foreach (var id in addBookRequestDTO.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = bookDomainModel.Id,
                    AuthorID = id
                };
                _dbContext.Books_Author.Add(_book_author);
                _dbContext.SaveChanges();
            }
            return addBookRequestDTO;
        }
        public AddBookRequestDTO? UpdateBookById(int id, AddBookRequestDTO bookDTO)
        {
            var bookDomain = _dbContext.Books.FirstOrDefault(n => n.Id == id);
            if (bookDomain != null)
            {
                bookDomain.Title = bookDTO.Title;
                bookDomain.Description = bookDTO.Description;
                bookDomain.IsRead = bookDTO.IsRead;
                bookDomain.DateRead = bookDTO.DateRead;
                bookDomain.Rate = bookDTO.Rate;
                bookDomain.Genre = bookDTO.Genre;
                bookDomain.CoverUrl = bookDTO.CoverUrl;
                bookDomain.DateAdded = bookDTO.DateAdded;
                bookDomain.PublishersId = bookDTO.PublisherId;
                _dbContext.SaveChanges();
            }
            var authorDomain = _dbContext.Books_Author.Where(a => a.BookId == id).ToList();
            if (authorDomain != null)
            {
                _dbContext.Books_Author.RemoveRange(authorDomain);
                _dbContext.SaveChanges();
            }
            foreach (var authorid in bookDTO.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = id,
                    AuthorID = authorid
                };
                _dbContext.Books_Author.Add(_book_author);
                _dbContext.SaveChanges();
            }
            return bookDTO;
        }

        public Book? DeleteBookById(int id)
        {
            var bookDomain = _dbContext.Books.FirstOrDefault(n => n.Id == id);
            if (bookDomain != null)
            {
                _dbContext.Books.Remove(bookDomain);
                _dbContext.SaveChanges();
            }
            return bookDomain;
        }
    }

}
