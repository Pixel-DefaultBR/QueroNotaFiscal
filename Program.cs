using Microsoft.EntityFrameworkCore;
using QueroNotaFiscal.Database;
using QueroNotaFiscal.Database.Repository.FiscalNote;
using QueroNotaFiscal.Services.FiscalNote;
using QueroNotaFiscal.Mappers;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddScoped<IFiscalNoteRepository, FiscalNoteRepository>();
builder.Services.AddScoped<IFiscalNotesService, FiscalNotesService>();

var config = new MapperConfiguration(cfg => 
{
    cfg.AddProfile(new FiscalNoteMapper());
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

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
