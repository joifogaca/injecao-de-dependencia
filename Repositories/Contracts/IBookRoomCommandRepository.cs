using DependencyRoomBooking.Model;

namespace DependencyRoomBooking.Repositories.Contracts
{
    public interface IBookRoomCommandRepository
    {
        Task<Customer?> GetCustomerByEmailAsync(string email);
        Task<Book?> GetRoomFromCommand(BookRoomCommand command);

        void CreateBook(Book book);
    }
}
