using Microsoft.EntityFrameworkCore;
using UltStore.Application.Abstractions.Authentication;
using UltStore.Application.Core.Authentication.CommandHandlers;
using UltStore.Infrastructure.Repositories.Authentication;
using UltStore.Persistance;
using MediatR; // Ensure MediatR namespace is included

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("Data Source=app.db");
});

builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
// the remaning repositories...

// Correctly configure MediatR services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();