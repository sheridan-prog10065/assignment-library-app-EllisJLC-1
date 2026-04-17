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
    public LoanPeriod(DateTime borrowedOn, DateTime returnedOn)
    {
        _borrowedOn = borrowedOn;
        _returnedOn = returnedOn;
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

    public TimeSpan? LatePeriod
    {
        get
        {
            if (DateTime.Now > _dueDate)
            {
                return null;
            } else
            {
                return _dueDate - DateTime.Now;
            }
        }
    }
    #endregion
}
