using Stripe;
using System.Threading.Tasks;

namespace ArtGallerySystem.Persistense
{
    public class StripePaymentService : IPaymentService
    {
        public StripePaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51PLPsOJJEr18PsGSINjOIjAssDKPtM7kMO7tqxylVlFGQhGNM8b6w1GlQky5jvcyfgeEEBQbMkNJGO17Ped7UXAw00QdZKBEwi"; 
        }

        public async Task<string> CreateAndConfirmPaymentIntent(string paymentMethodId, long amount, string currency)
        {
            try
            {
                var paymentIntentService = new PaymentIntentService();
                var paymentIntentOptions = new PaymentIntentCreateOptions
                {
                    Amount = amount, 
                    Currency = currency, 
                    PaymentMethod = paymentMethodId,
                    AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                    {
                        Enabled = true,
                        AllowRedirects = "never",
                    },
                };

                var paymentIntent = await paymentIntentService.CreateAsync(paymentIntentOptions);

                if (paymentIntent.Status == "requires_confirmation")
                {
                    var confirmOptions = new PaymentIntentConfirmOptions
                    {
                        PaymentMethod = paymentMethodId,
                    };
                    paymentIntent = await paymentIntentService.ConfirmAsync(paymentIntent.Id, confirmOptions);
                }

                return paymentIntent.Status;
            }
            catch (StripeException ex)
            {
                throw new Exception($"Stripe Error: {ex.StripeError.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
