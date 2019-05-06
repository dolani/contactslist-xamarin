using SQLite;

namespace ContactsList.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
