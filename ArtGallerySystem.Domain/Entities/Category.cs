using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Entities
{
    public class Category : Entity
    {
        private Category()
        {
        }
        public Category(string name, string description, int discount)
        {
            Name = name;
            Description = description;
            Discount = discount;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
    }
}
