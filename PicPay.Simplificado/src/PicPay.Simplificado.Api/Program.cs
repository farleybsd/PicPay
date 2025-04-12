var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServerDb(builder.Configuration);
builder.Services.AddRepository();
builder.Services.AddCommand();
builder.Services.AddMapper();
builder.Services.AddServicoAutorizacao(builder.Configuration);
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails(); // recomendado
builder.Logging.AddConsole(); // <-- habilita saída no console

var app = builder.Build();
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterUsuarioComumEndpoints();
app.RegisterTransferenciaEndpoints();
app.UseHttpsRedirection();

app.Run();