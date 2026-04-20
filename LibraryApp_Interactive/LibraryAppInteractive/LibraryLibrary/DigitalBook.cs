using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public class DigitalBook : Book
{
    #region fieldvars
    int _maxBorrowDays;
    float _latePenalty;
    #endregion

    #region constructor
    public DigitalBook(string bookName, string bookISBN, bool audio = false) : base(bookName, bookISBN)
    {
        _bookName = bookName;
        _ISBN = bookISBN;
        if (audio == true)
        {
            _bookType = BookType.Audio;
        } else
        {
            _bookType = BookType.Digital;
        }
    }
    #endregion

    #region methods

    /// <summary>
    /// Get loan license
    /// </summary>
    public void DetermineLoanLicense(Random random)
    {
        _maxBorrowDays = random.Next(2 * 7, 8 * 7);
        _latePenalty = 0.1f + (float)(random.NextDouble() * 0.4);
    }

    /// <summary>
    /// Borrow digital book
    /// </summary>
    /// <returns></returns>
    public LibraryAsset BorrowBook()
    {
        (bool available, LibraryAsset asset) = CheckAvailability();
        asset.Status = AssetStatus.Loaned;

        LoanPeriod loan = new LoanPeriod();
        loan.DueDate = DateTime.Now.AddDays(_maxBorrowDays);
        asset.Loan = loan;
        return asset;
    }

    /// <summary>
    /// Return digital book
    /// </summary>
    /// <param name="libID"></param>
    /// <returns></returns>
    public override (TimeSpan, int, decimal) ReturnBook(int libID)
    {
        (TimeSpan loanTime, int daysLate, decimal lateFee) = base.ReturnBook(libID);

        if (daysLate != null)
        {
            lateFee = (decimal)daysLate * (decimal)_latePenalty;
        }

        return (loanTime, daysLate, lateFee);
    }
    #endregion

}
