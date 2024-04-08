using ArtGalleryApp.Services;
using System.Diagnostics;

namespace ArtGalleryApp.Entities;

public class AccountsSystem(IDbService dbService)
{
    private List<Client> Clients { get; set; } = [];
    private List<Admin> Admins { get; set; } = [];
    private User? CurrentUser { get; set; }
    
    public void LoadData()
    {
        Clients = (List<Client>)dbService.GetAllEntities<Client>();
        Admins = (List<Admin>)dbService.GetAllEntities<Admin>();
    }

    public void RegisterClient(string password, string name, string surname, string email, string phone)
    {
        Client client = new(password, name, surname, email, phone);
        Clients.Add(client);
        dbService.AddEntity(client);
    }
    public void RegisterAdmin(string password, string name, string surname, string email, string phone)
    {
        Admin admin = new(password, name, surname, email, phone);
        Admins.Add(admin);
        dbService.AddEntity(admin);
    }
    public void Login(string login, string password)
    {
        if (login == "admin")
        {
            var admin = Admins.Find(admin => admin.Password == password);
            if (admin != null)
            {
                admin.IsLoggedIn = true;
                CurrentUser = admin;
            }
            else
            {
                throw new Exception("Invalid login or password");
            }
        }
        else
        {
            var client = Clients.Find(client => client.Email == login || client.Phone == login);
            if (client != null)
            {
                if (client.Password == password)
                {
                    client.IsLoggedIn = true;
                    CurrentUser = client;

                    Debug.WriteLine('\n');
                    Debug.WriteLine("Client is logged in");
                }
                else
                {
                    throw new Exception("Invalid password");
                }
            }
            else
            {
                throw new Exception("Invalid login");
            }
        }
    }
    public void Logout(string login, string password)
    {
        if (login == "admin")
        {
            var admin = Admins.Find(admin => admin.Password == password);
            if (admin != null)
            {
                admin.IsLoggedIn = false;
                CurrentUser = null;
            }
        }
        else
        {
            var client = Clients.Find(client => client.Email == login || client.Phone == login);
            if (client != null)
            {
                client.IsLoggedIn = false;
                CurrentUser = null;
            }
        }
    }   
    public User? GetCurrentUser()
    {
        return CurrentUser;
    }
    public IEnumerable<Client> GetClients()
    {
        return Clients;
    }
    public IEnumerable<Admin> GetAdmins()
    {
        return Admins;
    }
}