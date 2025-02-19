using ControleFinanceiro.Api.Configurations;
using ControleFinanceiro.Business.Interfaces.Repository;
using ControleFinanceiro.Business.UseCases.Expenses.Add;
using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(AddExpenseCommand));
builder.Services.AddCORS(builder.Configuration);

builder.Services.AddDbContext<ControleFinanceiroContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQL_SERVER"),
    b => b.MigrationsAssembly("ControleFinanceiro.Data"))) ;
//dotnet ef migrations add add_gategories --project ../ControleFinanceiro.Data
//dotnet ef database update --project ../ControleFinanceiro.Data

//Estando no diretorio de Data
//dotnet ef migrations add AddPrepexInContract --startup-project ../VLI.Jetsons.Application/VLI.Jetsons.Application.csproj

builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
