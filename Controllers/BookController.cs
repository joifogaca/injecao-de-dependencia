using Dapper;
using DependencyRoomBooking.Model;
using DependencyRoomBooking.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace DependencyRoomBooking.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRoomCommandRepository _bookRoomCommandRepository;

    public BookController(IBookRoomCommandRepository bookRoomCommandRepository)
    {
        _bookRoomCommandRepository = bookRoomCommandRepository;
    }
    public async Task<IActionResult> Book(BookRoomCommand command)
    {
        // Recupera o usuário
        var customer = _bookRoomCommandRepository.GetCustomerByEmailAsync(command.Email);

        if (customer == null)
            return NotFound();

        // Verifica se a sala está disponível
        var room = _bookRoomCommandRepository.GetRoomFromCommand(command);

        // Se existe uma reserva, a sala está indisponível
        if (room is not null)
            return BadRequest();

        // Tenta fazer um pagamento
        var client = new RestClient("https://payments.com");
        var request = new RestRequest()
            .AddQueryParameter("api_key", "c20c8acb-bd76-4597-ac89-10fd955ac60d")
            .AddJsonBody(new
            {
                User = command.Email,
                CreditCard = command.CreditCard
            });
        var response = await client.PostAsync<PaymentResponse>(request, new CancellationToken());

        // Se a requisição não pode ser completa
        if (response is null)
            return BadRequest();

        // Se o status foi diferente de "pago"
        if (response?.Status != "paid")
            return BadRequest();

        // Cria a reserva
        var book = new Book(command.Email, command.RoomId, command.Day);

        // Salva os dados
       _bookRoomCommandRepository.CreateBook(book);

        // Retorna o número da reserva
        return Ok();
    }
}
