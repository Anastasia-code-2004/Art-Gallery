using SQLite;


namespace ArtGalleryApp.Entities;

[Table("Client")]
public class Client(string password, string name, string surname, string email, string phone)
    : User(password, name, surname, email, phone)
{
    public event EventHandler BankCardsChanged;
    public Client() : this("", "", "", "", "")
    {
        // Этот конструктор без параметров не делает ничего, но он требуется для работы с SQLite
    }
    
    public void AddBankCard(string cardNumber, string cvv, string expiryDate)
    {
         BankCard bankCard = new(cardNumber, cvv, expiryDate);
         BankCardsChanged?.Invoke(bankCard, EventArgs.Empty);
   }
}