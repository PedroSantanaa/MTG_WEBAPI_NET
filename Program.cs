using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MTG_WebAPI_NET.Data;
using MTG_WebAPI_NET.Services.CardService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "MTG Cards API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Pedro Santana ",
            Url = new Uri("https://github.com/PedroSantanaa")
        },
    });
    c.EnableAnnotations();
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICardService, CardService>();

var app = builder.Build();

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
