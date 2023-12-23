using Dapper;
using DependencyRoomBooking.Model;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace DependencyRoomBooking.Repositories
{
   
    public class BookRoomCommandRepository : IBookRoomCommandRepository
    {
        private readonly SqlConnection _connection;

        public BookRoomCommandRepository(SqlConnection connection)
           => _connection = connection;

        public void CreateBook(Book book)
        {
            var query = $"INSERT INTO [Book] VALUES( {book.Date }, {book.Email},{book.Room})";
            _connection.Execute(query);
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            var query = $"SELECT * FROM [Customer] WHERE [Email]={email}";
            return await _connection.QueryFirstAsync<Customer>(query);
        }

        public async Task<Book?> GetRoomFromCommand(BookRoomCommand command)
        {
            var dateEnd = command.Day.Date.AddDays(1).AddTicks(-1);
            var query = $"SELECT * FROM [Book] WHERE [Room]={command.RoomId} AND [Date] BETWEEN {command.Day.Date} AND {dateEnd}";
            return await _connection.QueryFirstAsync<Book>(query);
        }

        
    }
}
