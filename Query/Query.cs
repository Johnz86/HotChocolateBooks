public class Query
{
    [UseProjection]
    [UseSorting]
    [UseFiltering]
    public IQueryable<Author> GetAuthors(ApplicationDbContext context)
    {
        return context.Authors;
    }

    [UseProjection]
    [UseSorting]
    [UseFiltering]
    public IQueryable<Book> GetBooks( ApplicationDbContext context)
    {
        return context.Books;
    }
}
