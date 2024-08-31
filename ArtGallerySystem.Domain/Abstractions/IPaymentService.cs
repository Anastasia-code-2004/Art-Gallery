using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.Domain.Abstractions
{
    public interface IPaymentService
    {
        Task<string> CreateAndConfirmPaymentIntent(string paymentMethodId, long amount, string currency);
    }
}
