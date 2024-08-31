using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Entities
{
    public class Admin : Entity
    {
        private Admin()
        {
        }
        public Admin(User personalData)
        {
            PersonalData = personalData;
        }
        public User PersonalData { get; set; }
    }
}
