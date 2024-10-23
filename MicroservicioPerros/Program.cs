using MicroservicioPerros.Business.Services;
using MicroservicioPerros.Data;
using MicroservicioPerros.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Preparar inyeccion de BD*/
var ConnectionString = Environment.GetEnvironmentVariable("CONN_STR");

builder.Services.AddDbContext<AppDBContext>(
    contexto => {
        contexto.UseMySQL(ConnectionString ?? builder.Configuration.GetConnectionString("DefaultConnection") ?? "");
    }

);
/*Inyectar repositorio*/
builder.Services.AddScoped<DogRepository>();
/*Inyectar servicio */
builder.Services.AddScoped<IDogService, DogServiceImp>();

/* Allow origins*/
builder.Services.AddCors(
    options => options.AddPolicy(name: "AllowAny", 
        configurePolicy: policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        })
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAny");

app.Run();
