using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public class Book
{
    #region fieldvars
    protected string _bookName;
    protected string _ISBN;
    protected string[]? _bookAuthorList;
    protected List<LibraryAsset>? _libAssetList;
    #endregion

    #region constructor
    public Book(string bookName, string bookISBN) {
        _bookName = bookName;
        _ISBN = bookISBN;
        _libAssetList = new List<LibraryAsset>();
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

    public string[] Authors
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
                return (true, null);
            }
        }
        return (false, FindNextAvailableAsset());
    }

    /// <summary>
    /// Allows user to borrow a book
    /// </summary>
    /// <returns></returns>
    public LibraryAsset BorrowBook()
    {
        LibraryAsset asset = FindNextAvailableAsset();
        if (asset == null)
        {
            throw new BookNotAvailableException("Book is not available to be borrowed");
        }

        LoanPeriod newLoan = new LoanPeriod();
        newLoan.BorrowedOn = DateTime.Now;
        newLoan.DueDate = DateTime.Now.AddDays(14);

        asset.Loan = newLoan;
        asset.Status = AssetStatus.Loaned;

        return asset;
    }

    /// <summary>
    /// Allows user to return a book based on the library Id number of the asset.
    /// </summary>
    /// <param name="libID"></param>
    /// <returns></returns>
    public virtual (TimeSpan, int, decimal) ReturnBook(int libID)
    {
        LibraryAsset asset = _libAssetList.Find(item => item.LibID == libID);
        asset.Status = AssetStatus.Available;

        TimeSpan borrowTime = DateTime.Now - asset.Loan.BorrowedOn;

        int lateDays = 0;
        decimal lateFee = 0m;

        if (asset.Loan.LatePeriod.Days > 0)
        {
            lateDays = (int)Math.Ceiling(asset.Loan.LatePeriod.TotalDays);
            lateFee = (decimal)PaperBook.LATE_PENALTY_PER_DAY * (decimal)lateDays;
        }

        LoanPeriod updateLoan = asset.Loan;
        updateLoan.ReturnedOn = DateTime.Now;

        asset.Loan = updateLoan;

        return (borrowTime, lateDays, lateFee);
    }


    /// <summary>
    /// Allow user to reserve a book given libID
    /// </summary>
    /// <param name="libID"></param>
    /// <returns></returns>
    public LibraryAsset ReserveBook()
    {
        LibraryAsset libAsset = FindNextAvailableAsset();
        if (libAsset != null)
        {
            libAsset.Status = AssetStatus.Reserved;
            
            return libAsset;
        }
        else
        {
            throw new LibraryIDException("That ID cannot be found, please try again.");
        }
    }


    /// <summary>
    /// Allow user to search for a library asset with LibID
    /// </summary>
    /// <param name="libID"></param>
    /// <returns></returns>
    public LibraryAsset FindLibraryAsset(int libID)
    {
        LibraryAsset libAsset = _libAssetList.Find(asset => asset.LibID == libID);
        return libAsset;
    }


    /// <summary>
    /// Find next asset that will be available
    /// </summary>
    /// <returns></returns>
    public LibraryAsset FindNextAvailableAsset()
    {
        LibraryAsset? nextAvailAsset = null;
        foreach (LibraryAsset asset in _libAssetList)
        {

            if (asset.Status == AssetStatus.Available)
            {
                return asset;
            }

            if (nextAvailAsset == null)
            {
                nextAvailAsset = asset;
            } else
            {
                if (asset.Loan.DueDate < nextAvailAsset.Loan.DueDate)
                {
                    nextAvailAsset = asset;
                }
            }
        }
        return nextAvailAsset;
    }

    public void AddLibAssets(LibraryAsset libAsset)
    {
        _libAssetList.Add(libAsset);
    }
    #endregion
}
