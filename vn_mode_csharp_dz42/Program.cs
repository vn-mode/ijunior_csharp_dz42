using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        const string enterAuthorMessage = "Введите имя автора, чтобы показать книги: ";
        const string enterTitleMessage = "Введите название книги, чтобы показать книги: ";
        const string enterYearMessage = "Введите год, чтобы показать книги: ";

        BookStore bookStore = new BookStore();

        bookStore.AddBook(new Book { Title = "Книга 1", Author = "Автор 1", Year = 2000 });
        bookStore.AddBook(new Book { Title = "Книга 2", Author = "Автор 2", Year = 2005 });
        bookStore.AddBook(new Book { Title = "Книга 3", Author = "Автор 1", Year = 2010 });
        bookStore.ShowAllBooks();

        Console.Write(enterAuthorMessage);
        string author = Console.ReadLine();
        bookStore.ShowBooksByAuthor(author);

        Console.Write(enterTitleMessage);
        string title = Console.ReadLine();
        bookStore.ShowBooksByTitle(title);

        Console.Write(enterYearMessage);
        int year = int.Parse(Console.ReadLine());
        bookStore.ShowBooksByYear(year);
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return $"Название: {Title}, Автор: {Author}, Год: {Year}";
    }
}

class BookStore
{
    private List<Book> books;

    public BookStore()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }

    public void ShowAllBooks()
    {
        const string allBooksMessage = "Все книги:";
        Console.WriteLine(allBooksMessage);
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    public void ShowBooksByAuthor(string author)
    {
        string booksByAuthorMessage = $"Книги автора {author}:";
        Console.WriteLine(booksByAuthorMessage);
        foreach (var book in books)
        {
            if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(book);
            }
        }
    }

    public void ShowBooksByTitle(string title)
    {
        string booksWithTitleMessage = $"Книги с названием '{title}':";
        Console.WriteLine(booksWithTitleMessage);
        foreach (var book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(book);
            }
        }
    }

    public void ShowBooksByYear(int year)
    {
        string booksByYearMessage = $"Книги, выпущенные в {year} году:";
        Console.WriteLine(booksByYearMessage);
        foreach (var book in books)
        {
            if (book.Year == year)
            {
                Console.WriteLine(book);
            }
        }
    }
}
