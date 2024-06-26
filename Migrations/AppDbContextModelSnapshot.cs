﻿// <auto-generated />
using System;
using LabAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LabAPI.Models.Domain.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Fujiko Fujio"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Trần Cao Duyên "
                        });
                });

            modelBuilder.Entity("LabAPI.Models.Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int>("PublishersId")
                        .HasColumnType("int");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublishersId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Doraemon",
                            Genre = "Nam",
                            IsRead = false,
                            PublishersId = 1,
                            Title = "Book 1"
                        },
                        new
                        {
                            Id = 2,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Cây Khế",
                            Genre = "Nam",
                            IsRead = false,
                            PublishersId = 2,
                            Title = "Book 2"
                        });
                });

            modelBuilder.Entity("LabAPI.Models.Domain.Book_Author", b =>
                {
                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("BookId", "AuthorID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Books_Author");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorID = 1,
                            Id = 1
                        },
                        new
                        {
                            BookId = 2,
                            AuthorID = 2,
                            Id = 2
                        });
                });

            modelBuilder.Entity("LabAPI.Models.Domain.Publishers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nhà Xuất Bản Kim Đồng"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bộ Giáo Dục"
                        });
                });

            modelBuilder.Entity("LabAPI.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtensison")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("MyImages", (string)null);
                });

            modelBuilder.Entity("LabAPI.Models.Domain.Book", b =>
                {
                    b.HasOne("LabAPI.Models.Domain.Publishers", "Publishers")
                        .WithMany("Books")
                        .HasForeignKey("PublishersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publishers");
                });

            modelBuilder.Entity("LabAPI.Models.Domain.Book_Author", b =>
                {
                    b.HasOne("LabAPI.Models.Domain.Author", "Author")
                        .WithMany("Book_Authors")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabAPI.Models.Domain.Book", "Book")
                        .WithMany("Book_Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LabAPI.Models.Domain.Author", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("LabAPI.Models.Domain.Book", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("LabAPI.Models.Domain.Publishers", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
