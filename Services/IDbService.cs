using ArtGalleryApp.Entities;
namespace ArtGalleryApp.Services;

public interface IDbService
{
    void CreateTable<T>();
    void AddEntity<T>(T entity);
    void DeleteEntity<T>(T entity);
    void UpdateEntity<T>(T entity);

    IEnumerable<T> GetAllEntities<T>() where T : class, new();
    IEnumerable<BankCard> GetBankCardsByClientId(int clientId);
}