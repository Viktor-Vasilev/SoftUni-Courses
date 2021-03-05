namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            // DbInitializer.ResetDatabase(db);

            // 1. Create Database BookShop

            // 2. Age Restriction
            // Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));

            // 3. Golden Books
            //Console.WriteLine(GetGoldenBooks(db));

            // 4. Books by Price
            //Console.WriteLine(GetBooksByPrice(db));

            // 5. Not Released In
            //Console.WriteLine(GetBooksNotReleasedIn(db, 2000));

            // 6. Book Titles by Category
            // Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));

            // 7. Released Before Date
            //Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));

            // 8. Author Search
            //Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));

            // 9. Book Search
            //Console.WriteLine(GetBookTitlesContaining(db, "sK"));

            // 10. Book Search by Author
            //Console.WriteLine(GetBooksByAuthor(db, "R"));

            // 11. Count Books
            //Console.WriteLine(CountBooks(db, 12));

            // 12. Total Book Copies
            //Console.WriteLine(CountCopiesByAuthor(db));

            // 13. Profit by Category
            //Console.WriteLine(GetTotalProfitByCategory(db));

            // 14. Most Recent Books
            //Console.WriteLine(GetMostRecentBooks(db));

            // 15. Increase Prices
            //IncreasePrices(db);

            // 16. Remove Books
            //Console.WriteLine(RemoveBooks(db));

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books.Where(books => books.AgeRestriction == ageRestriction)
            .Select(book => book.Title)
            .OrderBy(title => title)
            .ToArray();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                 .Where(book => book.EditionType == EditionType.Gold && book.Copies < 5000)
                 .Select(book => new
                 {
                     book.BookId,
                     book.Title
                 })
                 .OrderBy(x => x.BookId)
                 .ToArray();
            var result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(books => books.Price > 40)
                .Select(books => new
                {
                    books.Title,
                    books.Price
                })
                .OrderByDescending(books => books.Price)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(book => book.ReleaseDate.Value.Year != year)
                .Select(book => new
                {
                    book.Title,
                    book.BookId,
                })
                .OrderBy(book => book.BookId)
                .ToArray();

            var result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            //var books = context.Books
            //    .Include(x => x.BookCategories)
            //    .ThenInclude(x => x.Category)
            //    .Where(book => book.BookCategories
            //        .Any(category => categories.Contains(category.Category.Name.ToLower())))
            //    .Select(books => books.Title)
            //    .OrderBy(title => title)
            //    .ToArray();
            // var result = string.Join(Environment.NewLine, books);

            // ако започнем от мапинг таблицата е по-добре:
            var allBookCategories = context.BooksCategories              
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .Select(books => books.Book.Title)
                .OrderBy(title => title)
                .ToArray();

            var result = string.Join(Environment.NewLine, allBookCategories);

            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(book => book.ReleaseDate.Value < targetDate)
                .Select(book => new
                {
                    book.Title,
                    book.EditionType,
                    book.Price,
                    book.ReleaseDate.Value
                })
                .OrderByDescending(books => books.Value)
                .ToArray();

            var result = string.Join(Environment.NewLine, books
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(author => author.FirstName.EndsWith(input))
                .Select(au => new
                {
                    au.FirstName,
                    au.LastName
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArray();

            var result = string.Join(Environment.NewLine, authors
                .Select(b => $"{b.FirstName} {b.LastName}"));

            return result;

        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
               .Where(book => book.Title.ToLower().Contains(input.ToLower()))
               .Select(book => new
                    {
                         book.Title
                    })
               .OrderBy(book => book.Title)
               .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }
            return sb.ToString().TrimEnd();

        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(book => book.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(book => new
                 {
                     book.Title,
                     AFN = book.Author.FirstName,
                     ALN = book.Author.LastName,
                     book.BookId,
                 })
                .OrderBy(book => book.BookId)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(book => $"{book.Title} ({book.AFN} {book.ALN})"));

            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(book => book.Title.Length > lengthCheck)
                .ToList();

            return books.Count();

        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(author => new
                {
                    author.FirstName,
                    author.LastName,
                    TotalCopies = author.Books.Sum(book => book.Copies)
                })
                .OrderByDescending(tc => tc.TotalCopies)
                .ToArray();

            var result = string.Join(Environment.NewLine, authors.Select(author => $"{author.FirstName} {author.LastName} - {author.TotalCopies}"));

            return result;

        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(category => new
                {
                    category.Name,
                    Profit = category.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(p => p.Profit)
                .ThenBy(x => x.Name)
                .ToArray();

            var result = string.Join(Environment.NewLine, categories.Select(category => $"{category.Name} ${category.Profit:F2}"));

            return result;

        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categotyBooks = context.Categories
               .Select(category => new
               {
                   CatName = category.Name,
                   Books = category.CategoryBooks.Select(b => new
                   {
                       b.Book.Title,
                       b.Book.ReleaseDate.Value
                   })
                   .OrderByDescending(b => b.Value)
                   .Take(3)
                   .ToArray()
               })
               .OrderBy(x => x.CatName)
               .ToArray();

            var sb = new StringBuilder();

            foreach (var category in categotyBooks)
            {
                sb.AppendLine($"--{category.CatName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();        

        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(d => d.ReleaseDate.Value.Year < 2020)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(c => c.Copies < 4200)
                .ToList();

            var result = booksToRemove.Count();

            context.Books.RemoveRange(booksToRemove);

            context.SaveChanges();

            return result;
        }

    }
}

