using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new Book("Книга 1", "Толстой", 2000));
        library.AddBook(new Book("Книга 2", "Пушкин", 2005));
        library.AddBook(new Book("Книга 3", "Пупкин", 2010));

        library.Work();
    }
}

class Book
{
    public string Title { get; }
    public string Author { get; }
    public int Year { get; }

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

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

        Console.WriteLine();
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

        Console.WriteLine();
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

        Console.WriteLine();
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

        Console.WriteLine();
    }

    public void Work()
    {
        const string EnterAuthorMessage = "Введите имя автора, чтобы показать книги: ";
        const string EnterTitleMessage = "Введите название книги, чтобы показать книги: ";
        const string EnterYearMessage = "Введите год, чтобы показать книги: ";

        const string CommandShowAllBooks = "1";
        const string CommandShowByAuthor = "2";
        const string CommandShowByTitle = "3";
        const string CommandShowByYear = "4";
        const string CommandAddBook = "5";
        const string CommandRemoveBook = "6";
        const string CommandExit = "7";

        const string MenuTitle = "Меню:";
        const string OptionShowAllBooks = $"{CommandShowAllBooks}. Показать все книги";
        const string OptionShowByAuthor = $"{CommandShowByAuthor}. Показать книги по автору";
        const string OptionShowByTitle = $"{CommandShowByTitle}. Показать книги по названию";
        const string OptionShowByYear = $"{CommandShowByYear}. Показать книги по году";
        const string OptionAddBook = $"{CommandAddBook}. Добавить книгу";
        const string OptionRemoveBook = $"{CommandRemoveBook}. Удалить книгу";
        const string OptionExit = $"{CommandExit}. Выйти";

        bool isWork = true;

        while (isWork)
        {
            Console.WriteLine(MenuTitle);
            Console.WriteLine(OptionShowAllBooks);
            Console.WriteLine(OptionShowByAuthor);
            Console.WriteLine(OptionShowByTitle);
            Console.WriteLine(OptionShowByYear);
            Console.WriteLine(OptionAddBook);
            Console.WriteLine(OptionRemoveBook);
            Console.WriteLine(OptionExit);

            Console.Write("Введите номер пункта: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case CommandShowAllBooks:
                    ShowAllBooks();
                    break;

                case CommandShowByAuthor:
                    Console.Write(EnterAuthorMessage);
                    string author = Console.ReadLine();
                    ShowBooksByAuthor(author);
                    break;

                case CommandShowByTitle:
                    Console.Write(EnterTitleMessage);
                    string title = Console.ReadLine();
                    ShowBooksByTitle(title);
                    break;

                case CommandShowByYear:
                    Console.Write(EnterYearMessage);
                    int year;

                    if (int.TryParse(Console.ReadLine(), out year))
                    {
                        ShowBooksByYear(year);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный год. Попробуйте еще раз.");
                    }
                    break;

                case CommandAddBook:
                    Console.Write("Введите название книги: ");
                    string newTitle = Console.ReadLine();
                    Console.Write("Введите автора книги: ");
                    string newAuthor = Console.ReadLine();
                    Console.Write("Введите год выпуска книги: ");
                    if (int.TryParse(Console.ReadLine(), out int newYear))
                    {
                        Book newBook = new Book(newTitle, newAuthor, newYear);
                        AddBook(newBook);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный год. Книга не добавлена.");
                    }
                    break;

                case CommandRemoveBook:
                    Console.Write("Введите название книги, которую хотите удалить: ");
                    string bookToRemoveTitle = Console.ReadLine();
                    bool removed = false;
                    foreach (var book in _books)
                    {
                        if (book.Title.Equals(bookToRemoveTitle, StringComparison.OrdinalIgnoreCase))
                        {
                            RemoveBook(book);
                            removed = true;
                            Console.WriteLine($"Книга '{book.Title}' успешно удалена.");
                            break;
                        }
                    }
                    if (!removed)
                    {
                        Console.WriteLine($"Книга с названием '{bookToRemoveTitle}' не найдена.");
                    }
                    break;

                case CommandExit:
                    isWork = false;
                    break;

                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
