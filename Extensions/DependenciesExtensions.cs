using DependencyRoomBooking.Repositories;
using DependencyRoomBooking.Repositories.Contracts;
using DependencyRoomBooking.Services.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DependencyRoomBooking.Extensions
{
    public static class DependenciesExtensions
    {
        public static void AddSqlConnection(
                this IServiceCollection services,
                string connectionString)
        {
            services.AddScoped<SqlConnection>(x
                => new SqlConnection(connectionString));
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.TryAddTransient<IBookRoomCommandRepository, BookRoomCommandRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPaymentService, PaymentService>();
        }

    }
}
