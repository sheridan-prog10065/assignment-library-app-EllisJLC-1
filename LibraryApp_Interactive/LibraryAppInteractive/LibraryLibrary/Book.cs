using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public class Book
{
    private string _bookName;
    private string _ISBN;
    private List<string> _bookAuthorList;
    private List<LibraryAsset> _libAssetList;

    public Book(string bookName, string bookISBN) {
        _bookName = bookName;
        _ISBN = bookISBN;
    }

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

    public LibraryAsset BorrowBook()
    {

    }

    public (TimeSpan, int, decimal) ReturnBook(int libID)
    {

    }

    public LibraryAsset ReserveBook(int libID)
    {

    }

    public LibraryAsset FindLibraryAsset(int libID)
    {

    }

    public LibraryAsset FindNextAvailableAsset()
    {

    }
}
