using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Entities
{
    public class CategoryMembership : Entity
    {
        private CategoryMembership()
        {
        }
        public CategoryMembership(string name, string description, decimal price, int duration)
        {
            Name = name;
            Description = description;
            Price = price;
            Duration = duration;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
 
}
