using CoreBusiness;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.SQL;
using UseCases.BlogImagesUseCases;
using UseCases.BlogsUseCases;
using UseCases.DataStorePluginInterfaces;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BisleriumContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BisleriumPrivate"));
});

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BisleriumContext>();

builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Repositories
builder.Services.AddTransient<IBlogRepository, BlogSqlRepository>();
builder.Services.AddTransient<IBlogImageRepository, BlogImageSqlRepository>();

// Use Cases
builder.Services.AddTransient<IAddBlogUseCase, AddBlogUseCase>();
builder.Services.AddTransient<IViewBlogsUseCase, ViewBlogsUseCase>();
builder.Services.AddTransient<IDeleteBlogUseCase, DeleteBlogUseCase>();
builder.Services.AddTransient<IEditBlogUseCase, EditBlogUseCase>();
builder.Services.AddTransient<IViewSelectedBlogUseCase, ViewSelectedBlogUseCase>();

builder.Services.AddTransient<IAddBlogImagesUseCases, AddBlogImagesUseCases>();
builder.Services.AddTransient<IDeleteBlogImageUseCase, DeleteBlogImageUseCase>();
builder.Services.AddTransient<IGetBlogImagesUseCase, GetBlogImagesUseCase>();


// Data Initializer
builder.Services.AddHostedService<DataInitializer>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();