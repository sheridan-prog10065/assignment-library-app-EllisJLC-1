using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public class PaperBook : Book
{
    #region constants
    public const int MAX_BORROW_DAYS = 30;
    public const float LATE_PENALTY_PER_DAY = 0.25f;
    #endregion

    #region constructor
    public PaperBook(string bookName, string bookISBN) : base(bookName, bookISBN)
    {
        _bookName = bookName;
        _ISBN = bookISBN;
    }
    #endregion

    #region methods
    public LibraryAsset BorrowBook()
    {
        (bool availability, LibraryAsset book) = base.CheckAvailability();
        return book;
    }

    public override (TimeSpan, int, decimal) ReturnBook(int libID)
    {
        (TimeSpan borrowTime, int lateDays, decimal lateFee) = base.ReturnBook(libID);

        lateFee = lateDays * (decimal)PaperBook.LATE_PENALTY_PER_DAY;

        return (borrowTime, lateDays, lateFee);

    }
    #endregion
}
