using Microsoft.EntityFrameworkCore;
using ShopWebAPITP3.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("ShopConnection")));

var app = builder.Build();
//Cada vez que se inicie el proyecto se va a ejecutar esto que ejecuta la migración es decir crear la BD o actualizarla
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ShopContext>();
    context.Database.Migrate();
}
//

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

