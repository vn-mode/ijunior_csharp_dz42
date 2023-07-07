using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        const string EnterAuthorMessage = "Введите имя автора, чтобы показать книги: ";
        const string EnterTitleMessage = "Введите название книги, чтобы показать книги: ";
        const string EnterYearMessage = "Введите год, чтобы показать книги: ";

        const string CommandShowAllBooks = "1";
        const string CommandShowByAuthor = "2";
        const string CommandShowByTitle = "3";
        const string CommandShowByYear = "4";
        const string CommandExit = "5";

        const string MenuTitle = "Меню:";
        const string OptionShowAllBooks = $"{CommandShowAllBooks}. Показать все книги";
        const string OptionShowByAuthor = $"{CommandShowByAuthor}. Показать книги по автору";
        const string OptionShowByTitle = $"{CommandShowByTitle}. Показать книги по названию";
        const string OptionShowByYear = $"{CommandShowByYear}. Показать книги по году";
        const string OptionExit = $"{CommandExit}. Выйти";

        Library library = new Library();

        library.AddBook(new Book { Title = "Книга 1", Author = "Автор 1", Year = 2000 });
        library.AddBook(new Book { Title = "Книга 2", Author = "Автор 2", Year = 2005 });
        library.AddBook(new Book { Title = "Книга 3", Author = "Автор 1", Year = 2010 });

        while (true)
        {
            Console.WriteLine(MenuTitle);
            Console.WriteLine(OptionShowAllBooks);
            Console.WriteLine(OptionShowByAuthor);
            Console.WriteLine(OptionShowByTitle);
            Console.WriteLine(OptionShowByYear);
            Console.WriteLine(OptionExit);

            Console.Write("Введите номер пункта: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            if (choice == CommandShowAllBooks)
            {
                library.ShowAllBooks();
            }
            else if (choice == CommandShowByAuthor)
            {
                Console.Write(EnterAuthorMessage);
                string author = Console.ReadLine();
                library.ShowBooksByAuthor(author);
            }
            else if (choice == CommandShowByTitle)
            {
                Console.Write(EnterTitleMessage);
                string title = Console.ReadLine();
                library.ShowBooksByTitle(title);
            }
            else if (choice == CommandShowByYear)
            {
                Console.Write(EnterYearMessage);
                int year;
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    library.ShowBooksByYear(year);
                }
                else
                {
                    Console.WriteLine("Некорректный год. Попробуйте еще раз.");
                }
            }
            else if (choice == CommandExit)
            {
                break;
            }
            else
            {
                Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
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
