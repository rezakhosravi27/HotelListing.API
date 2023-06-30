using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("alowAll", b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

var connectionString = builder.Configuration.GetConnectionString("HotelListing.Api");
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSerilogRequestLogging(); 

app.UseCors("alowAll"); 

app.UseAuthorization();

app.MapControllers();

app.Run();
