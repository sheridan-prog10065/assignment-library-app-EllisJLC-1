using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLibrary;

public struct LoanPeriod
{
    #region fieldvars
    DateTime _borrowedOn;
    DateTime _returnedOn;
    DateTime _dueDate;
    #endregion

    #region constructor
    public LoanPeriod(DateTime borrowedOn, DateTime dueDate)
    {
        _borrowedOn = borrowedOn;
        _dueDate = dueDate;
    }
    #endregion

    #region properties
    public DateTime BorrowedOn
    {
        get { return _borrowedOn; }
        set { _borrowedOn = value; }
    }

    public DateTime ReturnedOn
    {
        get { return _returnedOn; }
        set { _returnedOn = value; }
    }

    public DateTime DueDate
    {
        get { return _dueDate; }
        set { _dueDate = value; }
    }

    public TimeSpan LoanDuration
    {
        get { return DateTime.Now - _borrowedOn; }
    }

    public TimeSpan LatePeriod
    {
        get
        {
            return (TimeSpan)(_dueDate - DateTime.Now);
        }
    }
    #endregion
}
