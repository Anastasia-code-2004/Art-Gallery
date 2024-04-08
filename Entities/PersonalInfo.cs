using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGalleryApp.Entities;

[Table("PersonalInfo")]
public class PersonalInfo(string name, string surname, string email, string phone)
    : BaseEntity
{
    [Required]
    public string Name { get; set; } = name;

    [Required]
    public string Surname { get; set; } = surname;

    [Required]
    public string Email { get; set; } = email;

    [Required]
    public string Phone { get; set; } = phone;

    public void ChangeInfo(string name, string surname, string email, string phone)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Phone = phone;
    }
}