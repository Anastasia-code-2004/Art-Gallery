using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryApp.Entities
{
    [Table("ClientBankCards")]
    class ClientBankCard : BaseEntity
    {
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        [ForeignKey(nameof(BankCard))]
        public int BankCardId { get; set; }

        public ClientBankCard() { }
        public ClientBankCard(int clientId, int bankCardId)
        {
            ClientId = clientId;
            BankCardId = bankCardId;
        }
    }
}
