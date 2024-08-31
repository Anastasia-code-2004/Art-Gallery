using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Entities
{
    public class Exhibition : Entity
    {
        private Exhibition()
        {
        }
        public Exhibition(string name, string description, DateTime startDate, DateTime endDate, decimal ticketPrice)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            TicketPrice = ticketPrice;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
