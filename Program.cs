using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add GraphQL Services
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseInMemoryDatabase("MyDb"));
    
builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<ApplicationDbContext>()
    .AddQueryType<Query>()
    .AddProjections()
    .AddSorting()
    .AddFiltering()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

// Add GraphQL endpoint
app.MapGraphQL();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DataSeeder.SeedData(dbContext);
}


app.Run();
