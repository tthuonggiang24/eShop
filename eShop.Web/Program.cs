using eShop.DataStore.HardCode;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.SearchProductScreen;
using eShop.UseCases.ViewProductScreen;
using eShop.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.ViewEngines;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<IProductRepository, ProductReponsitory>();

builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
