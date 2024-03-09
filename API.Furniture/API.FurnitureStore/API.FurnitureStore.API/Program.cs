using API.FurnitureStore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<APIFurnitureStoreContext>(options => options.UseSqlite(builder.Configuration
    .GetConnectionString("APIFurnitureStoreContext")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();