using DependencyRoomBooking.Model;

namespace DependencyRoomBooking.Services.Contracts
{
    public interface IPaymentService
    {
        Task<PaymentResponse> MakePayment(BookRoomCommand command);
    }
}
