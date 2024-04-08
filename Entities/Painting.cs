using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace ArtGalleryApp.Entities;

[Table("Painting")]
public class Painting : BaseEntity
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public int YearOfCreation { get; set; }
    [Required]
    public string ImagePath { get; set; }
    public void ChangeInfo(string name, string author, int yearOfCreation, string imagePath)
    {
        Name = name;
        Author = author;
        YearOfCreation = yearOfCreation;
        ImagePath = imagePath;
    }
}