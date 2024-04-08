using SQLite;

namespace ArtGalleryApp.Entities;

[Table("Admin")]

public class Admin(string password, string name, string surname, string email, string phone)
    : User(password, name, surname, email, phone)
{
    
    public Admin() : this("", "", "", "", "")
    {
        // Этот конструктор без параметров не делает ничего, но он требуется для работы с SQLite
    }
    public void AddPaintingToDatabase(string name, string author, int year, string imagePath)
    {
        // Создаем новую картину
        Painting painting = new Painting
        {
            Name = name,
            Author = author,
            YearOfCreation = year,
            ImagePath = imagePath
        };

        // Добавляем картину в базу данных
        // _dbService - это ваш сервис для работы с базой данных
        
    }
}