using System.Xml.Linq;

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
    private Random _randomID;
    private Random _randomETC;
    #endregion

    #region constants
    public const int DEFAULT_LIBID_START = 100;
    #endregion

    #region constructor
    public Library()
    {
        _bookList = new List<Book>();
        _libIDGeneratorSeed = DEFAULT_LIBID_START;
        _randomID = new Random(_libIDGeneratorSeed);
        _randomETC = new Random();
    }
    #endregion

    #region methods
    /// <summary>
    /// Create a set of default books to add to library
    /// </summary>
    public void CreateDefaultBooks()
    {
        PaperBook newBook = new PaperBook("How to Write Good", "10D-024");
        newBook.Authors = [
            "Steve Stevenson",
            "John Johnson"
            ];

        for (int iBook = 0; iBook < 5; iBook++)
        {
            LibraryAsset newAsset = new LibraryAsset(DetermineLibId(), newBook);
            newBook.AddLibAssets(newAsset);
        }
        _bookList.Add(newBook);

        DigitalBook newDigitalBook = new DigitalBook("How to Read Good", "20E-292");
        newDigitalBook.Authors = [
            "John Doe",
            "Jane Doe"
            ];

        for (int iBook = 0; iBook < 3; iBook++)
        {
            LibraryAsset newAsset = new LibraryAsset(DetermineLibId(), newDigitalBook);
            newDigitalBook.AddLibAssets(newAsset);
        }
        _bookList.Add(newDigitalBook);
    }


    /// <summary>
    /// Using random, create a method that determines libId to be used for new books to be added
    /// </summary>
    /// <returns></returns>
    public int DetermineLibId()
    {
        return _randomID.Next(99999);    
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
    public void RegisterBook(string bookName, string bookISBN, string[] authors, BookType bookType, int nCopies)
    {
        if (bookType == BookType.Paper)
        {
            PaperBook newBook = new PaperBook(bookName, bookISBN);
            newBook.Authors = authors;
        }
        else if (bookType == BookType.Audio || bookType == BookType.Digital)
        {
            DigitalBook newBook = new DigitalBook(bookName, bookISBN);
        }

    }

    /// <summary>
    /// Find book by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Book FindBookByName(string name)
    {
        Book searchResult = _bookList.Find(book =>  book.Name == name);
        return searchResult;
    }

    /// <summary>
    /// Find book by ISBN
    /// </summary>
    /// <param name="ISBN"></param>
    /// <returns></returns>
    public Book FindBookByISBN(string ISBN) 
    {
        Book searchResult = _bookList.Find(book => book.ISBN == ISBN);
        return searchResult;
    }
    #endregion
}