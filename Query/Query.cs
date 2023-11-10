using HotChocolate;
using HotChocolate.Data;
using System.Linq;

public class Query
{
    [UseDbContext(typeof(MyDbContext))]
    [UseProjection]
    [UseSorting]
    [UseFiltering]
    public IQueryable<Author> GetAuthors([Service(ServiceKind.Pooled)] MyDbContext context)
    {
        return context.Authors;
    }

    [UseDbContext(typeof(MyDbContext))]
    [UseProjection]
    [UseSorting]
    [UseFiltering]
    public IQueryable<Book> GetBooks([Service(ServiceKind.Pooled)] MyDbContext context)
    {
        return context.Books;
    }
}
