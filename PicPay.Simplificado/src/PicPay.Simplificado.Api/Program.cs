using PicPay.Simplificado.Api.Extensions;
using PicPay.Simplificado.Infrastructure.Extensions.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServerDb(builder.Configuration);
builder.Services.AddRepository();
builder.Services.AddCommand();
builder.Services.AddMapper();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterUsuarioComumEndpoints();
app.UseHttpsRedirection();

app.Run();
