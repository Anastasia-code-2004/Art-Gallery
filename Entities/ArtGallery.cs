using ArtGalleryApp.Services;
using System.Diagnostics;

namespace ArtGalleryApp.Entities;

public class ArtGallery
{
    private readonly AccountsSystem _accountsSystem;
    public List<Painting> Paintings { get; set; }
    private readonly IDbService _dbService;
    public event EventHandler? PaintingsChanged;
    public ArtGallery(AccountsSystem accountsSystem, IDbService dbService)
    {
        _accountsSystem = accountsSystem;
        _dbService = dbService;
        _dbService.CreateTable<Client>();
        _dbService.CreateTable<BankCard>();
        _dbService.CreateTable<ClientBankCard>();
        _dbService.CreateTable<Admin>();
        _dbService.CreateTable<Painting>();
        Paintings = [];
        LoadData();
        SubscribeToEvents();
    }
    protected virtual void OnPaintingsChanged()
    {
        PaintingsChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RegisterClient(string password, string name, string surname, string email, string phone)
    {
        _accountsSystem.RegisterClient(password, name, surname, email, phone);
    }
    public void RegisterAdmin(string password, string name, string surname, string email, string phone)
    {
        _accountsSystem.RegisterAdmin(password, name, surname, email, phone);
    }
    public void Login(string login, string password)
    {
        Debug.WriteLine("Login method is called");
        _accountsSystem.Login(login, password);
    }
    public void Logout(string login, string password)
    {
        _accountsSystem.Logout(login, password);
    }

    private void LoadData()
    {
        _accountsSystem.LoadData();   
        Paintings = (List<Painting>)_dbService.GetAllEntities<Painting>();
    }
    private void SubscribeToEvents()
    {
        var clients = _accountsSystem.GetClients();
        foreach (var client in clients)
        {
            client.BankCardsChanged += AddBankCard;
        }
    }
    public void AddPainting(Painting painting)
    {
        Paintings.Add(painting);
        _dbService.AddEntity(painting);
        OnPaintingsChanged();
    }
    public void DeletePainting(Painting painting)
    {
        Paintings.Remove(painting);
        _dbService.DeleteEntity(painting);
        OnPaintingsChanged();
    }
    public User? GetCurrentUser()
    {
        return _accountsSystem.GetCurrentUser();
    }
    public IEnumerable<Client> GetClients()
    {
        return _accountsSystem.GetClients();
    }
    public IEnumerable<Admin> GetAdmins()
    {
        return _accountsSystem.GetAdmins();
    }  
    public void AddBankCard(object? sender, EventArgs e)
    {
        var bankCard = (BankCard)sender;
        _dbService.AddEntity(bankCard);
        ClientBankCard clientBankCard = new(GetCurrentUser().ID, bankCard.ID);
        _dbService.AddEntity(clientBankCard);
    }

    public IEnumerable<BankCard> GetBankCardsByClientId(int clientId)
    {
        return _dbService.GetBankCardsByClientId(clientId);
    }
}