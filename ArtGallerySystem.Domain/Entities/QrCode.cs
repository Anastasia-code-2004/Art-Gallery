using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Entities
{
    public class QrCode : Entity
    {
        private QrCode()
        {
        }
        public QrCode(int exhibitionId, int clientId, int membershipId, bool isUsed = false)
        {
            ExhibitionId = exhibitionId;
            ClientId = clientId;
            MembershipId = membershipId;
            IsUsed = isUsed;
        }
        public int ExhibitionId { get; set; }

        [ForeignKey("ExhibitionId")]
        public virtual Exhibition Exhibition { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public int MembershipId { get; set; }
        [ForeignKey("MembershipId")]
        public virtual Membership Membership { get; set; }
        public bool IsUsed { get; set; }

    }
}
