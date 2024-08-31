using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Entities
{
    public class Ticket : Entity
    {
        private Ticket()
        {
        }
        public Ticket(int exhibitionId, int clientId, int categoryId, decimal price, DateTime purchaseTime)
        {
            ExhibitionId = exhibitionId;
            ClientId = clientId;
            CategoryId = categoryId;
            Price = price;
            PurchaseTime = purchaseTime;
        }
        public int ExhibitionId { get; set; }

        [ForeignKey("ExhibitionId")]
        public virtual Exhibition Exhibition { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public decimal Price { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}
