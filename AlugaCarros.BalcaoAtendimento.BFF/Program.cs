using AlugaCarros.BalcaoAtendimento.BFF.Configuration;
using AlugaCarros.Core.ApiConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiConfiguration(builder.Configuration);

builder.AddSerilog("AlugaCarros.BalcaoAtendimento.BFF");

var app = builder.Build();

app.UseAppConfiguration();

app.Run();
