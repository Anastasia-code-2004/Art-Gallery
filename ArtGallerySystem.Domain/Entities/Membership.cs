using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Entities
{
    public class Membership : Entity
    {
        public Membership()
        {
            ClientId = 0;
            CategoryMembershipId = 0;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }
        public Membership(int clientId, int categoryMembershipId, DateTime startDate, DateTime endDate)
        {
            ClientId = clientId;
            CategoryMembershipId = categoryMembershipId;
            StartDate = startDate;
            EndDate = endDate;
        }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public int CategoryMembershipId { get; set; }
        [ForeignKey("CategoryMembershipId")]
        public virtual CategoryMembership CategoryMembership { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
