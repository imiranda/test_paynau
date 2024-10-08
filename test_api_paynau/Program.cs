using Microsoft.EntityFrameworkCore;
using test_api_paynau.Interfaces;
using test_api_paynau.Models;
using test_api_paynau.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PaynauContext>(options =>
{
    options.UseMySql(
        connetionString, ServerVersion.AutoDetect(connetionString)
    );
});

builder.Services.AddScoped<IRepository<Person>, PersonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(x => x
       .AllowAnyMethod()
       .AllowAnyHeader()
       .SetIsOriginAllowed(origin => true) // allow any origin
       .AllowCredentials()); // allow credentials
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
