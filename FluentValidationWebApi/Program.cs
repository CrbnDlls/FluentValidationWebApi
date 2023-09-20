using AutoMapper;
using FluentValidation;
using FluentValidationWebApi.AutoMapper;
using FluentValidationWebApi.Interfaces;
using FluentValidationWebApi.Models;
using FluentValidationWebApi.Repositories;
using FluentValidationWebApi.Validators;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IMapper mapper = new MapperConfiguration(config =>
{
    config.AddProfile(new StudentProfile());
}).CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IValidator<StudentBindingModel>, StudentBindingValidator>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
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
