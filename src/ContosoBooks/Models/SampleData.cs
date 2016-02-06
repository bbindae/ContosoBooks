using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace ContosoBooks.Models
{
    public class SampleData
    {
        public static void Initializie(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Book.Any())
            {
                var austen = context.Author.Add(
                    new Author {LastName = "Austen", FirstMidName = "Jane"}).Entity;

                var dickens = context.Author.Add(
                    new Author {LastName = "Dickens", FirstMidName = "Charles"}).Entity;

                var cervantes = context.Author.Add(
                    new Author {LastName = "Cervantes", FirstMidName = "Miguel"}).Entity;

                context.Book.AddRange(
                    new Book()
                    {
                        Title = "Pride and Prejudice",
                        Year = 1813,
                        Author = austen,
                        Price = 9.9M,
                        Genre = "Comedy of manners"
                    },
                    new Book()
                    {
                        Title = "Northanger Abbey",
                        Year = 1817,
                        Author = austen,
                        Price = 12.95M,
                        Genre = "Gothic parody"
                    },
                    new Book()
                    {
                        Title = "David Copperfield",
                        Year = 1850,
                        Author = dickens,
                        Price = 15M,
                        Genre = "Bildungsroman"
                    },
                    new Book()
                    {
                        Title = "Don Quioxte",
                        Year = 1617,
                        Author = cervantes,
                        Price = 8.95M,
                        Genre = "Picaresque"
                    });
                context.SaveChanges();
            }
        }
    }
}
