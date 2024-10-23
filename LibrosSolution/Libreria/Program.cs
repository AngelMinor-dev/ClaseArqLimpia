using Libreria.Business.Services;
using Libreria.Data;
using Libreria.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDBContext>(
    context => {
        context.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
);

builder.Services.AddScoped<BookRepository>();

builder.Services.AddScoped<ILibreriaService,LibreriaServiceImp>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
