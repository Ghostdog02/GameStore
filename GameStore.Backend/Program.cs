using GameStore.Backend.Data;
using GameStore.Backend.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connectionString);
//builder.Services.AddScoped<GameStoreContext>();

var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();
