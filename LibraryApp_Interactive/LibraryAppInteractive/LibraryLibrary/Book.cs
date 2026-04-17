using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public class Book
{
    #region fieldvars
    private string _bookName;
    private string _ISBN;
    private List<string> _bookAuthorList;
    private List<LibraryAsset> _libAssetList;
    #endregion

    #region constructor
    public Book(string bookName, string bookISBN) {
        _bookName = bookName;
        _ISBN = bookISBN;
    }
    #endregion

    #region properties
    public string Name
    {
        get { return _bookName; }
        set { _bookName = value; }
    }

    public string ISBN
    {
        get { return _ISBN; }
        set { _ISBN = value; }
    }

    public List<string> Authors
    {
        get { return _bookAuthorList; }
        set { _bookAuthorList = value; }
    }

    public IEnumerable<LibraryAsset> Assets
    {
        get { return _libAssetList; }
    }
    #endregion

    #region methods

    /// <summary>
    /// Get book availability
    /// </summary>
    /// <returns></returns>
    public (bool, LibraryAsset?) CheckAvailability()
    {
        foreach (LibraryAsset asset in _libAssetList)
        {
            if (asset.IsAvailable)
            {
                return (true, asset);
            }
        }
        return (false, null);
    }

    /// <summary>
    /// Allows user to borrow a book
    /// </summary>
    /// <returns></returns>
    public LibraryAsset BorrowBook()
    {

    }

    /// <summary>
    /// Allows user to return a book based on the library Id number of the asset.
    /// </summary>
    /// <param name="libID"></param>
    /// <returns></returns>
    public (TimeSpan, int, decimal) ReturnBook(int libID)
    {

    }


    /// <summary>
    /// Allow user to reserve a book given libID
    /// </summary>
    /// <param name="libID"></param>
    /// <returns></returns>
    public LibraryAsset ReserveBook(int libID)
    {

    }


    /// <summary>
    /// Allow user to search for a library asset with LibID
    /// </summary>
    /// <param name="libID"></param>
    /// <returns></returns>
    public LibraryAsset FindLibraryAsset(int libID)
    {

    }


    /// <summary>
    /// Find next time asset will be available
    /// </summary>
    /// <returns></returns>
    public LibraryAsset FindNextAvailableAsset()
    {

    }
    #endregion
}
