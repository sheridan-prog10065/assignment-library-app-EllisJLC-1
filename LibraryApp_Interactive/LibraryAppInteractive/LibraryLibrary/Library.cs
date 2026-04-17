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
    #region fieldvars
    private List<Book> _bookList;
    private int _libIDGeneratorSeed;
    private Random _random;
    #endregion

    #region constants
    public const int DEFAULT_LIBID_START = 100;
    #endregion

    #region constructor
    public Library()
    {
        _bookList = new List<Book>();
    }
    #endregion

    #region methods
    /// <summary>
    /// Create a set of default books to add to library
    /// </summary>
    public void CreateDefaultBooks()
    {
        Book newBook = new Book("How to Write Good", "10D024");
        newBook.Authors = [
            "Steve Stevenson",
            "John Johnson"
            ];
    }


    /// <summary>
    /// Using random, create a method that determines libId to be used for new books to be added
    /// </summary>
    /// <returns></returns>
    public int DetermineLibId()
    {
        
    }

    /// <summary>
    /// Create a new book with given data, return created book?
    /// </summary>
    /// <param name="bookName"></param>
    /// <param name="bookISBN"></param>
    /// <param name="authors"></param>
    /// <param name="bookType"></param>
    /// <param name="nCopies"></param>
    /// <returns></returns>
    public Book RegisterBook(string bookName, string bookISBN, string[] authors, BookType bookType, int nCopies)
    {
        
    }

    /// <summary>
    /// Find book by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Book FindBookByName(string name)
    {
        
    }

    /// <summary>
    /// Find book by ISBN
    /// </summary>
    /// <param name="ISBN"></param>
    /// <returns></returns>
    public Book FindBookByISBN(string ISBN) 
    { 
        
    }
    #endregion
}