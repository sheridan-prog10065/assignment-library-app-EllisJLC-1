using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public class DigitalBook : Book
{
    #region fieldvars
    int _maxBorrowDays;
    float _latePentalty;
    #endregion

    #region constructor
    public DigitalBook(string bookName, string bookISBN) : base(bookName, bookISBN)
    {
    }
    #endregion

    #region methods

    /// <summary>
    /// Get loan license
    /// </summary>
    public void DetermineLoanLicense()
    {

    }

    /// <summary>
    /// Borrow digital book
    /// </summary>
    /// <returns></returns>
    public LibraryAsset BorrowBook()
    {

    }

    /// <summary>
    /// Return digital book
    /// </summary>
    /// <param name="libID"></param>
    /// <returns></returns>
    public (TimeSpan, int, decimal) ReturnBook(int libID)
    {

    }
    #endregion

}
