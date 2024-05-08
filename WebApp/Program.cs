using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using UseCases.BlogsUseCases;
using UseCases.DataStorePluginInterfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BisleriumContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BisleriumPrivate"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IBlogRepository, BlogsInMemoryRepository>();
builder.Services.AddTransient<IViewBlogsUseCase, ViewBlogsUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();