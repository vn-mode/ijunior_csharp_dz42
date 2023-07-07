using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        const string EnterAuthorMessage = "Введите имя автора, чтобы показать книги: ";
        const string EnterTitleMessage = "Введите название книги, чтобы показать книги: ";
        const string EnterYearMessage = "Введите год, чтобы показать книги: ";

        Library library = new Library();

        library.AddBook(new Book { Title = "Книга 1", Author = "Автор 1", Year = 2000 });
        library.AddBook(new Book { Title = "Книга 2", Author = "Автор 2", Year = 2005 });
        library.AddBook(new Book { Title = "Книга 3", Author = "Автор 1", Year = 2010 });

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Показать все книги");
            Console.WriteLine("2. Показать книги по автору");
            Console.WriteLine("3. Показать книги по названию");
            Console.WriteLine("4. Показать книги по году");
            Console.WriteLine("5. Выйти");

            Console.Write("Введите номер пункта: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    library.ShowAllBooks();
                    break;
                case "2":
                    Console.Write(EnterAuthorMessage);
                    string author = Console.ReadLine();
                    library.ShowBooksByAuthor(author);
                    break;
                case "3":
                    Console.Write(EnterTitleMessage);
                    string title = Console.ReadLine();
                    library.ShowBooksByTitle(title);
                    break;
                case "4":
                    Console.Write(EnterYearMessage);
                    int year = int.Parse(Console.ReadLine());
                    library.ShowBooksByYear(year);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                    break;
            }

            Console.WriteLine();
        }
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

class Library
{
    private List<Book> _books;

    public Library()
    {
        _books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        _books.Remove(book);
    }

    public void ShowAllBooks()
    {
        const string AllBooksMessage = "Все книги:";
        Console.WriteLine(AllBooksMessage);
        foreach (var book in _books)
        {
            Console.WriteLine(book);
        }
    }

    public void ShowBooksByAuthor(string author)
    {
        string booksByAuthorMessage = $"Книги автора {author}:";
        Console.WriteLine(booksByAuthorMessage);
        foreach (var book in _books)
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
        foreach (var book in _books)
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
        foreach (var book in _books)
        {
            if (book.Year == year)
            {
                Console.WriteLine(book);
            }
        }
    }
}
