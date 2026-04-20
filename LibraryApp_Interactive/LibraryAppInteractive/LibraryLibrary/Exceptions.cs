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

public class AssetUnavailableException : Exception
{
    public AssetUnavailableException(string message) : base(message)
    {

    }
}

public class TypeException : Exception
{
    public TypeException(string message) : base(message)
    {

    }
}