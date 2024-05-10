using CoreBusiness;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.SQL;
using UseCases.BlogActionsUseCases;
using UseCases.BlogImagesUseCases;
using UseCases.BlogReactionsUseCases;
using UseCases.BlogsUseCases;
using UseCases.CommentActionsUseCases;
using UseCases.CommentReactionsUseCases;
using UseCases.CommentsUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.NotificationsUseCases;
using UseCases.ReactionTypeUseCases;
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
builder.Services.AddTransient<IReactionTypeRepository, ReactionTypeSqlRepository>();
builder.Services.AddTransient<IBlogReactionRepository, BlogReactionSqlRepository>();
builder.Services.AddTransient<ICommentRepository, CommentSqlRepository>();
builder.Services.AddTransient<ICommentReactionRepository, CommentReactionSqlRepository>();
builder.Services.AddTransient<INotificationRepository, NotificationSqlRepository>();
builder.Services.AddTransient<IBlogActionRepository, BlogActionSqlRepository>();
builder.Services.AddTransient<ICommentActionRepository, CommentActionSqlRepository>();

/*
 * Use Cases
 */

// Use Cases - Reaction Types
builder.Services.AddTransient<IGetReactionTypeByActivityNameUseCase, GetReactionTypeByActivityNameUseCase>();

// Use Cases - Blogs
builder.Services.AddTransient<IGetAllBlogsUseCase, GetAllBlogsUseCase>();
builder.Services.AddTransient<IAddBlogUseCase, AddBlogUseCase>();
builder.Services.AddTransient<IViewBlogsUseCase, ViewBlogsUseCase>();
builder.Services.AddTransient<IDeleteBlogUseCase, DeleteBlogUseCase>();
builder.Services.AddTransient<IEditBlogUseCase, EditBlogUseCase>();
builder.Services.AddTransient<IViewSelectedBlogUseCase, ViewSelectedBlogUseCase>();
builder.Services.AddTransient<IGetTop10BlogsUseCase, GetTop10BlogsUseCase>();
builder.Services.AddTransient<IGetTotalBlogsUseCase, GetTotalBlogsUseCase>();
builder.Services.AddTransient<IGetTop10BloggersUseCase, GetTop10BloggersUseCase>();

// Use Cases - Blogs Images
builder.Services.AddTransient<IAddBlogImagesUseCases, AddBlogImagesUseCases>();
builder.Services.AddTransient<IDeleteBlogImageUseCase, DeleteBlogImageUseCase>();
builder.Services.AddTransient<IGetBlogImagesUseCase, GetBlogImagesUseCase>();
builder.Services.AddTransient<IGetBlogImageUseCase, GetBlogImageUseCase>();

// Use Cases - Blogs Reactions
builder.Services.AddTransient<IAddBlogReactionUseCase, AddBlogReactionUseCase>();
builder.Services.AddTransient<IGetBlogReactionsByBlogIdUseCase, GetBlogReactionsByBlogIdUseCase>();
builder.Services.AddTransient<IDeleteBlogReactionUseCase, DeleteBlogReactionUseCase>();
builder.Services.AddTransient<IGetUpvotesByMonthUseCase, GetUpvotesByMonthUseCase>();
builder.Services.AddTransient<IGetDownvotesByMonthUseCase, GetDownvotesByMonthUseCase>();

// Use Cases - Comments
builder.Services.AddTransient<IGetAllCommentsUseCase, GetAllCommentsUseCase>();
builder.Services.AddTransient<IAddCommentUseCase, AddCommentUseCase>();
builder.Services.AddTransient<IGetCommentsByBlogIdUseCase, GetCommentsByBlogIdUseCase>();
builder.Services.AddTransient<IGetCommentByIdUseCase, GetCommentByIdUseCase>();
builder.Services.AddTransient<IUpdateCommentUseCase, UpdateCommentUseCase>();
builder.Services.AddTransient<IDeleteCommentUseCase, DeleteCommentUseCase>();
builder.Services.AddTransient<IGetCommentCountByMonthUseCase, GetCommentCountByMonthUseCase>();

// Use Cases - Comments Reactions
builder.Services.AddTransient<IAddCommentReactionUseCase, AddCommentReactionUseCase>();
builder.Services.AddTransient<IGetCommentReactionsByCommentIdUseCase, GetCommentReactionsByCommentIdUseCase>();
builder.Services.AddTransient<IDeleteCommentReactionUseCase, DeleteCommentReactionUseCase>();

// Use Cases - Notifications
builder.Services.AddTransient<IAddNotificationUseCase, AddNotificationUseCase>();
builder.Services.AddTransient<IGetNotificationsByUserIdUseCase, GetNotificationsByUserIdUseCase>();
builder.Services.AddTransient<IMarkNotificationAsSeenUseCase, MarkNotificationAsSeenUseCase>();

// Use Cases - Blog Actions
builder.Services.AddTransient<IAddBlogActionUseCase, AddBlogActionUseCase>();
builder.Services.AddTransient<IGetBlogActionsByBlogIdUseCase, GetBlogActionsByBlogIdUseCase>();

// Use Cases - Comment Actions
builder.Services.AddTransient<IAddCommentActionUseCase, AddCommentActionUseCase>();
builder.Services.AddTransient<IGetCommentActionsByCommentIdUseCase, GetCommentActionsByCommentIdUseCase>();


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
    pattern: "{controller=Blogs}/{action=Index}/{id?}");

app.Run();