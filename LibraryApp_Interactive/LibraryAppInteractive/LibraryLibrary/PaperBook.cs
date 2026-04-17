using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public class PaperBook : Book
{
    #region constants
    const int MAX_BORROW_DAYS = 30;
    const float LATE_PENALTY_PER_DAY = 0.25f;
    #endregion

    #region constructor
    public PaperBook(string bookName, string bookISBN) : base(bookName, bookISBN)
    {

    }
    #endregion

    #region methods
    public LibraryAsset BorrowBook()
    {
        
    }
    #endregion
}
