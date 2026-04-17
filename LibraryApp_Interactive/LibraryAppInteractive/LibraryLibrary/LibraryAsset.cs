using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public class LibraryAsset
{
    #region fieldvars
    Book _book;
    int _libID;
    AssetStatus _status;
    LoanPeriod _loanPeriod;
    #endregion

    #region constructor
    public LibraryAsset(int libID, Book book)
    {
        _libID = libID;
        _book = book;
    }
    #endregion

    #region properties
    public int LibID
    {
        get { return _libID; }
        set { _libID = value; }
    }

    public AssetStatus Status
    {
        get { return _status; }
        set { _status = value; }
    }

    public LoanPeriod Loan
    {
        get { return _loanPeriod; }
        set { _loanPeriod = value; }
    }

    public bool IsAvailable
    {
        get { 
            switch (_status)
            {
                case AssetStatus.Available:
                    return true;

                case AssetStatus.NotAvailable:
                    return false;

                case AssetStatus.Loaned:
                    return false;

                case AssetStatus.Reserved:
                    return false;

                default:
                    throw new ArgumentException("Book status invalid");
            }
        }
    }
    #endregion
}
