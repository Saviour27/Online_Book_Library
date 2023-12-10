using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Books>().HasData(
                new Books
                {
                    Id = 1,
                    Title = "Harry Potter and the Prisoner of Azkaban",
                   ImageURL = "images/Fiction/drama/download.jpeg",
                    Description = "Magic",
                    Author = "J.K Rowling",
                    Pages = 780,
                    Publisher = "Bloomsbury",
                    Language = "English",
                    ISBN = "975609876112",
                    LibraryAddDate = DateTime.Now,
                    CopiesInLibrary = 50,
                    CopiesOutLibrary = 3,
                    AvailableCopies = 47,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    DeletedAt = null,
                    EVersion = true,
                    GenreId = 1
                });

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Drama",
                },
                new Genre
                {
                    Id = 2,
                    Name = "Horror",
                },
                new Genre
                {
                    Id = 3,
                    Name = "Mystery"
                },
                 new Genre
                 {
                     Id = 4,
                     Name = "Sci_Fi",
                 },
                new Genre
                {
                    Id = 5,
                    Name = "Art",
                },
                 new Genre
                 {
                     Id = 6,
                     Name = "Biography",
                 },
                new Genre
                {
                    Id = 7,
                    Name = "Sport",
                },
                new Genre
                {
                    Id = 8,
                    Name = "Travel",
                },
                 new Genre
                 {
                     Id = 9,
                     Name = "Blues",
                 },
                new Genre
                {
                    Id = 10,
                    Name = "Classic",
                },
                  new Genre
                  {
                      Id = 11,
                      Name = "Folk",
                  },
                 new Genre
                 {
                     Id = 12,
                     Name = "Hip_Hop",
                 },
                new Genre
                {
                    Id = 13,
                    Name = "Rap",
                },
                 new Genre
                 {
                     Id = 14,
                     Name = "Reggae",
                 },
                new Genre
                {
                    Id = 15,
                    Name = " Rock",
                });
        }
    }
}