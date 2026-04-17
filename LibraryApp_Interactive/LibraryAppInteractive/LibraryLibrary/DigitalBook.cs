using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public class DigitalBook : Book
{
    int _maxBorrowDays;
    float _latePentalty;
    public DigitalBook(string bookName, string bookISBN) : base(bookName, bookISBN)
    {
    }

    public void DetermineLoanLicense()
    {

    }

    public LibraryAsset BorrowBook()
    {

    }

    public (TimeSpan, int, decimal) ReturnBook(int libID)
    {

    }

}
