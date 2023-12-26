using DependencyRoomBooking.Model;
using RestSharp;

namespace DependencyRoomBooking.Services.Contracts
{
    public class PaymentService : IPaymentService
    {
        public async Task<PaymentResponse?> MakePayment(BookRoomCommand command)
        {
            var client = new RestClient("https://payments.com");
            var request = new RestRequest()
                .AddQueryParameter("api_key", "c20c8acb-bd76-4597-ac89-10fd955ac60d")
                .AddJsonBody(new
                {
                    User = command.Email,
                    CreditCard = command.CreditCard
                });
            return await client.PostAsync<PaymentResponse>(request, new CancellationToken());
        }
    }
}
