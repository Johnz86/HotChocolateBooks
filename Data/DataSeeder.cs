public static class DataSeeder
{
    public static void SeedData(ApplicationDbContext context)
    {
        // Check if the database is empty
        if (!context.Authors.Any() && !context.Books.Any())
        {
            // Create some fake authors
            var authors = new List<Author>
            {
                new Author { Name = "Author 1", Books = new List<Book>() },
                new Author { Name = "Author 2", Books = new List<Book>() },
                // Add more authors as needed
            };

            // Create some fake books and associate them with authors
            authors[0].Books.Add(new Book { Title = "Book 1 by Author 1" });
            authors[0].Books.Add(new Book { Title = "Book 2 by Author 1" });
            authors[1].Books.Add(new Book { Title = "Book 1 by Author 2" });
            // Add more books as needed

            // Add the authors (and their books) to the context
            context.Authors.AddRange(authors);

            // Save changes to the database
            context.SaveChanges();
        }
    }
}
