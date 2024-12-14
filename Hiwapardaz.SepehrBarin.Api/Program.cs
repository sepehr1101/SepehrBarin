using Hiwapardaz.SepehrBarin.Api.Extensions;
using Hiwapardaz.SepehrBarin.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddUserPoolExtensions();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomDbContext(configuration);

builder.Services.UpdateAndSeedUserPoolDb();
builder.Services.AddCustomCors();
//builder.Services.AddCustomAntiforgery();
builder.Services.AddCustomOptions(configuration);

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
