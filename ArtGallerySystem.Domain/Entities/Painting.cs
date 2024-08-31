using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Entities
{
    public class Painting : Entity
    {
        private Painting()
        {
        }
        public Painting(string name, string author, int yearOfCreation, string description, byte [] photo)
        {
            Name = name;
            Author = author;
            Description = description;
            YearOfCreation = yearOfCreation;
            ExhibitionId = 0;
            IsInExhibition = false;
            Photo = photo;
        }
        public string Name { get; set; }
        public string Author { get; set; }
        public int YearOfCreation { get; set; }
        public string Description { get; set; }
        public int ExhibitionId { get; private set; }

        public byte[] Photo { get; set; }
        public bool IsInExhibition { get; set; }
        public void SetExhibition(int exhibitionId)
        {
            if (exhibitionId <= 0) return;
            ExhibitionId = exhibitionId;
            IsInExhibition = true;
        }
        public void RemoveExhibition()
        {
            ExhibitionId = 0;
            IsInExhibition = false;
        }
    }
}
