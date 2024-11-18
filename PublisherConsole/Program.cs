using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

//GetAuthors();
//AddAuthor();
//GetAuthors();
AddAuthorWithBook();


void AddAuthorWithBook()
{
    var author = new Author { FirstName = "John", LastName = "Doe" };
    author.Books.Add(new Book
    {
        Title = "Programming Entity Framework",
        PublishDate = new DateOnly(2009, 1, 1)
    });

    author.Books.Add(new Book
    {
        Title = "Programming Entity Framework 2nd Ed",
        PublishDate = new DateOnly(2010, 8, 1)
    });
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(a => a.Books).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach (var book in author.Books)
        {
            Console.WriteLine(book.Title);
        }

    }
}

void AddAuthor()
{
    var author = new Author
    {
        FirstName = "John",
        LastName = "Doe"
    };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthors()
{
    using var context = new PubContext();

    var authors = context.Authors.ToList();

    //var authors = (from author in context.Authors
    //               select author).ToList();

    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}