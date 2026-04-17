namespace LibraryLibrary;

/// <summary>
/// Defines the Library class used to manage the library books and assets.
///
/// NOTE: A single object/instance of this class (called a "singleton") is created and shared automatically
/// with the two pages in the application through the process of Dependency Injection handled and configured
/// in MauiProgram class.  
/// </summary>
public class Library
{
    private List<Book> _bookList;
    private int _libIDGeneratorSeed;
    private Random _random;
    public const int DEFAULT_LIBID_START = 100;

    public Library()
    {

    }

    public void CreateDefaultBooks()
    {

    }

    public int DetermineLibId()
    {

    }

    public Book RegisterBook(string bookName, string bookISBN, string[] authors, BookType bookType, int nCopies)
    {

    }

    public Book FindBookByName(string name)
    {

    }

    public Book FindBookByISBN(string ISBN) 
    { 
        
    }
}