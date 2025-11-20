
using Microsoft.AspNetCore.SignalR;
﻿using Eventos_PuntoNet.Components;
using Eventos_PuntoNet.Components.Data;
using Eventos_PuntoNet.Components.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Taller_Eventos_PuntoNet.Components;
using Tarea_SingalR.Hubs;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddHttpClient();
builder.Services.AddSignalR();

builder.Services.AddSingleton<SeguimientoService>();

//builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddQuickGridEntityFrameworkAdapter();

// 🔹 Servicios de Razor y Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7046") // origen del proyecto MVC
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Configure the HTTP request pipeline.
// 🔹 Base de datos
builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


// 🔹 Servicio de sesión
builder.Services.AddScoped<SessionService>();

// 🔹 Antiforgery (necesario desde .NET 9)
builder.Services.AddAntiforgery();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.UseSession();

// 🔹 IMPORTANTE: agregar antes del mapeo de componentes
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseCors();

app.MapHub<EventoHub>("/EventoHub");

var scope = app.Services.CreateScope();
var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<EventoHub>>();

app.Run();
