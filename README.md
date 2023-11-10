# HotChocolateBooks Project

This project demonstrates a basic GraphQL API using Hot Chocolate in .NET. The API allows querying for authors and their books.

## Requirements

- .NET 6.0 SDK or later

### Running the Application

To run the application, navigate to the root directory of the project in your command line interface and execute:

```powershell
dotnet run
```

The application will start, and you can access the GraphQL endpoint at [http://localhost:5285/graphql](http://localhost:5285/graphql).
This should open the Banana Cake Pop interface. 

Banana Cake Pop is a GraphQL IDE, which is included with Hot Chocolate, to test and explore your GraphQL API.


### Executing a Query

To execute a query in Banana Cake Pop:

- In the query editor on the left side, enter your GraphQL query. 

For example:
```graphql
query {
    authors {
    name
    books {
        title
    }
    }
}
```

- Click the "Play" button or press Ctrl + Enter to run the query.

- The results will be displayed on the right side.
  This example query fetches all authors with their names and the titles of their books.

### Project Structure

- Query: Contains GraphQL query definitions.
- Model: Defines the Author and Book entities.
- Data: Includes the database context and data seeding logic.

Feel free to explore and modify the project to better understand how Hot Chocolate and GraphQL work in a .NET environment.