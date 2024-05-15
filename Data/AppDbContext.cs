using LabAPI.Models.Domain;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using LabAPI.Models.DTO;
using LabAPI.Models;

namespace LabAPI.Data
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<Publishers> Publishers { get; set; }
            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<Book_Author> Books_Author { get; set; }
            public DbSet<Image> Images { get; set; }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.Entity<Book_Author>()
                    .HasKey(bc => new { bc.BookId, bc.AuthorID });

                builder.Entity<Book_Author>()
                    .HasOne(bc => bc.Book)
                    .WithMany(b => b.Book_Authors)
                    .HasForeignKey(bc => bc.BookId);

                builder.Entity<Book_Author>()
                    .HasOne(bc => bc.Author)
                    .WithMany(a => a.Book_Authors)
                    .HasForeignKey(bc => bc.AuthorID);
            new DbInitializer(builder).Seed();
            builder.Entity<Image>()
             .ToTable("MyImages");
            }
            public class DbInitializer
            {
                private readonly ModelBuilder _builder;
                public DbInitializer(ModelBuilder builder)
                {
                    this._builder = builder;
                }
                public void Seed()
                {
                _builder.Entity<Book>().HasData(
                        new Book
                        {
                            Id = 1,
                            Title = "Book 1",
                            Description = "Doraemon",
                            PublishersId = 1, // Sử dụng navigation property Publishers
                            Genre = "Nam"
                        },
                         new Book
                         {
                             Id = 2,
                             Title = "Book 2",
                             Description = "Cây Khế",
                             PublishersId = 2, // Thay vì sử dụng navigation property, bạn có thể sử dụng PublisherId
                             Genre = "Nam"
                         }
                     );

                _builder.Entity<Author>().HasData(
                        new Author
                        {
                            Id = 1,
                            FullName = "Fujiko Fujio",
                        },
                        new Author
                        {
                            Id = 2,
                            FullName = "Trần Cao Duyên ",
                        }
                    );
                    _builder.Entity<Publishers>().HasData(
                        new Publishers
                        {
                            Id = 1,
                            Name = "Nhà Xuất Bản Kim Đồng",
                        },
                        new Publishers
                        {
                            Id = 2,
                            Name = "Bộ Giáo Dục",
                        }
                    );
                    _builder.Entity<Book_Author>().HasData(
                       new Book_Author
                       {
                           Id = 1,
                           BookId = 1,
                           AuthorID = 1
                       },   
                       new Book_Author
                       {
                           Id = 2,
                           BookId = 2,
                           AuthorID = 2
                       }
                       );
                }
            }
        }
    }
