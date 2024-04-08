using SQLite;
using ArtGalleryApp.Entities;
using System.Diagnostics;
namespace ArtGalleryApp.Services;

public class SQLiteService : IDbService
{
    private readonly SQLiteConnection? _database;
    
    public SQLiteService()
    {
        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var dataBasePath = Path.Combine(folderPath, "ArtGallery.db");

        // Debug.WriteLine('\n');
        // Debug.WriteLine("Database path: ");
        // Debug.WriteLine(dataBasePath);

        _database = new SQLiteConnection(dataBasePath);
        _database.DeleteAll<BankCard>();
    }

    public void AddEntity<T>(T entity)
    {
        _database.Insert(entity);
    }
    public void DeleteEntity<T>(T entity)
    {
        _database.Delete(entity);
    }
    public void UpdateEntity<T>(T entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAllEntities<T>() where T : class, new()
    {
        return _database.Table<T>().ToList();
    }

    private bool TableExists(string tableName)
    {
        return _database?.GetTableInfo(tableName).Any() ?? false;
    }
    public void CreateTable<T>()
    {
        if (!TableExists(typeof(T).Name))
        {
            _database.CreateTable<T>();
        }
    }
    public IEnumerable<BankCard> GetBankCardsByClientId(int clientId)
    {
        var query = _database.Table<ClientBankCard>()
            .Where(est => est.ClientId == clientId)
            .Join(_database.Table<BankCard>(),
                est => est.BankCardId,
                st => st.ID,
                (est, st) => st);

        foreach (var bankCard in query)
        {
            Debug.WriteLine($"Bank card {bankCard.CardNumber}");
        }

        return query.ToList();
    }
}
