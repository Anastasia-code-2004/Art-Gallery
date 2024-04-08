using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryApp.Entities
{
    [Table("BankCard")]
    public class BankCard : BaseEntity
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
        }

        [MaxLength(16), Required]  
        public string CardNumber { get; set; } 

        [MaxLength(4), Required]  
        public string CVV { get; set; } 

        [MaxLength(7), Required]
        public string ExpiryDate { get; set; } 

    }
}
