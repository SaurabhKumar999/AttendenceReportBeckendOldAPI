using Domain_Layer.Data;
using Domain_Layer.Model;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.IRepository;
using Repository_Layer.Repository;
using Service_Layer.IService;
using Service_Layer.Service;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS to allow requests from any origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();

    });
});
//configration
builder.Services.AddDbContext<AppDBContext>(OptionsBuilderConfigurationExtensions =>
OptionsBuilderConfigurationExtensions.UseSqlServer("Server=.\\sqlexpress;Database=AttendenceData;Encrypt=False;Integrated Security=True;"));

//inject dependency
builder.Services.AddScoped(typeof(IAttRepository<>), typeof(AttRepository<>));
builder.Services.AddScoped<IAttService<Attendences>, AttService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Use CORS before UseAuthorization and UseEndpoints
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();

