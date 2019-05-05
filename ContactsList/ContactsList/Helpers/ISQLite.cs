using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsList.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
