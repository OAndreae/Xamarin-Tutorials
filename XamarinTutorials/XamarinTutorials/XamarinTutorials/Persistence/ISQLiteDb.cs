using SQLite;

namespace XamarinTutorials
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
