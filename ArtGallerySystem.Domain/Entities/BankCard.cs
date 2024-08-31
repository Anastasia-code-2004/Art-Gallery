using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Entities
{
    public class BankCard : Entity
    {
        public BankCard()
        {
            CardNumber = CVV = ExpiryDate = "";
        }

        public BankCard(string cardNumber, string cvv, string expiryDate)
        {
            CardNumber = cardNumber;
            CVV = cvv;
            ExpiryDate = expiryDate;
            ClientId = 0;
        }

        [MaxLength(16), Required]
        public string CardNumber { get; set; }

        [MaxLength(4), Required]
        public string CVV { get; set; }

        [MaxLength(7), Required]
        public string ExpiryDate { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public void SetClient(int clientId)
        {
            if (clientId <= 0) return;
            ClientId = clientId;
        }

        public void RemoveClient()
        {
            ClientId = 0;
        }
    }
}
