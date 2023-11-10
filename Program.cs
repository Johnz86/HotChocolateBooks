using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add GraphQL Services
builder.Services.AddPooledDbContextFactory<MyDbContext>(options => 
    options.UseInMemoryDatabase("MyDb"));
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddSorting()
    .AddFiltering();

// Swagger/OpenAPI setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

// Add GraphQL endpoint
app.MapGraphQL();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MyDbContext>>();
    using var dbContext = dbContextFactory.CreateDbContext();
    DataSeeder.SeedData(dbContext);
}

app.Run();
