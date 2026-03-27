using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Data.Entities;
using System.Reflection.Emit;

namespace Presentation.Data.EntityConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> modelBuilder)
        { 
           modelBuilder.
                HasOne(b => b.Category)
               .WithMany(c => c.Books)
               .HasForeignKey(b => b.CategoryId)
               .OnDelete(DeleteBehavior.SetNull);

          modelBuilder.HasData
                (
                    new Book { Id = 1, BookName = "To Kill a Mockingbird", Author = "Harper Lee", PageCount = 281, Description = "Classic of modern American literature", CategoryId = 1 },
                    new Book { Id = 2, BookName = "1984", Author = "George Orwell", PageCount = 328, Description = "Dystopian social science fiction novel", CategoryId = 1 },
                    new Book { Id = 3, BookName = "The Great Gatsby", Author = "F. Scott Fitzgerald", PageCount = 180, Description = "Story of the Jazz Age", CategoryId = 1 },
                    new Book { Id = 4, BookName = "A Brief History of Time", Author = "Stephen Hawking", PageCount = 212, Description = "Cosmology for everyone", CategoryId = 2 },
                    new Book { Id = 5, BookName = "The Selfish Gene", Author = "Richard Dawkins", PageCount = 360, Description = "Gene-centered view of evolution", CategoryId = 2 },
                    new Book { Id = 6, BookName = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", PageCount = 498, Description = "History of humankind from ancient times", CategoryId = 3 },
                    new Book { Id = 7, BookName = "Guns, Germs, and Steel", Author = "Jared Diamond", PageCount = 480, Description = "Factors shaping human societies", CategoryId = 3 },
                    new Book { Id = 8, BookName = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", PageCount = 309, Description = "The first Harry Potter adventure", CategoryId = 4 },
                    new Book { Id = 9, BookName = "The Hobbit", Author = "J.R.R. Tolkien", PageCount = 310, Description = "Bilbo's adventure to the Lonely Mountain", CategoryId = 4 },
                    new Book { Id = 10, BookName = "The Lord of the Rings", Author = "J.R.R. Tolkien", PageCount = 1178, Description = "Epic fantasy trilogy", CategoryId = 4 },
                    new Book { Id = 11, BookName = "Steve Jobs", Author = "Walter Isaacson", PageCount = 656, Description = "Biography of Apple co-founder", CategoryId = 5 },
                    new Book { Id = 12, BookName = "Becoming", Author = "Michelle Obama", PageCount = 448, Description = "Memoir of the former First Lady", CategoryId = 5 },
                    new Book { Id = 13, BookName = "The Catcher in the Rye", Author = "J.D. Salinger", PageCount = 214, Description = "Story of teenage angst", CategoryId = 1 },
                    new Book { Id = 14, BookName = "Brave New World", Author = "Aldous Huxley", PageCount = 268, Description = "Dystopian futuristic society", CategoryId = 1 },
                    new Book { Id = 15, BookName = "The Elegant Universe", Author = "Brian Greene", PageCount = 425, Description = "String theory explained", CategoryId = 2 },
                    new Book { Id = 16, BookName = "Cosmos", Author = "Carl Sagan", PageCount = 396, Description = "Exploration of the universe", CategoryId = 2 },
                    new Book { Id = 17, BookName = "Alexander Hamilton", Author = "Ron Chernow", PageCount = 818, Description = "Biography of founding father", CategoryId = 5 },
                    new Book { Id = 18, BookName = "The Diary of a Young Girl", Author = "Anne Frank", PageCount = 283, Description = "Diary of Anne Frank during WWII", CategoryId = 5 },
                    new Book { Id = 19, BookName = "The Silmarillion", Author = "J.R.R. Tolkien", PageCount = 365, Description = "Mythology of Middle-earth", CategoryId = 4 },
                    new Book { Id = 20, BookName = "Moby Dick", Author = "Herman Melville", PageCount = 635, Description = "Epic tale of a whale hunt", CategoryId = 1 }
                );
        }
    }
}
