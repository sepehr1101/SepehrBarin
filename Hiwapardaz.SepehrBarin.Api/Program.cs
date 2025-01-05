using Hiwapardaz.SepehrBarin.Api.ExceptionHandlers;
using Hiwapardaz.SepehrBarin.Api.Extensions;
using Hiwapardaz.SepehrBarin.Persistence.Extensions;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();//.AddSwaggerGen();

builder.Services.AddCustomDbContext(configuration);
builder.Services.AddCustomJwtBearer(configuration);

builder.Services.UpdateAndSeedUserPoolDb();
builder.Services.AddCustomCors();
//builder.Services.AddCustomAntiforgery();
builder.Services.AddCustomOptions(configuration);

//Exceptions

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
