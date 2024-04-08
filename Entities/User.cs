using Microsoft.Maui.ApplicationModel.Communication;
using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.Maui.ApplicationModel.Permissions;
using System.Xml.Linq;

namespace ArtGalleryApp.Entities;

public class User(string password, string name, string surname, string email, string phone) : BaseEntity
{
    [Required]
    public string? Password { get; set; } = password;

    [Required]
    public string Name { get; set; } = name;

    [Required]
    public string Surname { get; set; } = surname;

    [Required]
    public string Email { get; set; } = email;

    [Required]
    public string Phone { get; set; } = phone;


    public bool IsLoggedIn { get; set; } = false;

    protected void ChangePassword(string password, string newpassword)
    {
        if (password == Password)
        {
            Password = newpassword;
        }
        else
        {
            throw new Exception("Invalid password");
        }
    }

    protected void ChangePersonalInfo(string name, string surname, string email, string phone)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Phone = phone;
    }
}
