using DependencyRoomBooking.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlConnection(connStr);
builder.Services.AddRepositories();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
