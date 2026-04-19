using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public class LibraryIDException : Exception
{
    public LibraryIDException(string message) : base(message)
    {

    }
}

public class BookNotAvailableException : Exception
{
    public BookNotAvailableException(string message) : base(message)
    {

    }
}
