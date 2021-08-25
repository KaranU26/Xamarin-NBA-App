using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace REALAssignMENT2
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
