using CoreBusiness;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.SQL.constants;

namespace Plugins.DataStore.SQL;

public class BisleriumContext : IdentityDbContext<User>
{
    public BisleriumContext(DbContextOptions<BisleriumContext> options) : base(options)
    {
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogAction> BlogActions { get; set; }
    public DbSet<BlogImage> BlogImages { get; set; }
    public DbSet<BlogReaction> BlogReactions { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentAction> CommentActions { get; set; }
    public DbSet<CommentReaction> CommentReactions { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<ReactionType> ReactionTypes { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /*
         * Relationships
         */

        // User -|------<- Blog
        modelBuilder.Entity<User>()
            .HasMany(u => u.Blogs)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId);

        // User -|------<- Notification
        modelBuilder.Entity<User>()
            .HasMany(u => u.Notifications)
            .WithOne(n => n.User)
            .HasForeignKey(n => n.UserId);

        // User -|------<- Comment
        modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // User -|------<- BlogReaction
        modelBuilder.Entity<User>()
            .HasMany(u => u.BlogReactions)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // User -|------<- CommentReaction
        modelBuilder.Entity<User>()
            .HasMany(u => u.CommentReactions)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Blog -|------<- BlogImage
        modelBuilder.Entity<Blog>()
            .HasMany(b => b.BlogImages)
            .WithOne(i => i.Blog)
            .HasForeignKey(i => i.BlogId);

        // Blog -|------<- BlogAction
        modelBuilder.Entity<Blog>()
            .HasMany(b => b.BlogActions)
            .WithOne(a => a.Blog)
            .HasForeignKey(a => a.BlogId);

        // Blog -|------<- BlogReaction
        modelBuilder.Entity<Blog>()
            .HasMany(b => b.BlogReactions)
            .WithOne(r => r.Blog)
            .HasForeignKey(r => r.BlogId);

        // Blog -|------<- Comment
        modelBuilder.Entity<Blog>()
            .HasMany(b => b.Comments)
            .WithOne(c => c.Blog)
            .HasForeignKey(c => c.BlogId)
            .OnDelete(DeleteBehavior.Restrict);

        // Comment -|------<- CommentAction
        modelBuilder.Entity<Comment>()
            .HasMany(c => c.CommentActions)
            .WithOne(a => a.Comment)
            .HasForeignKey(a => a.CommentId);

        // Comment -|------<- CommentReaction
        modelBuilder.Entity<Comment>()
            .HasMany(c => c.CommentReactions)
            .WithOne(r => r.Comment)
            .HasForeignKey(r => r.CommentId);

        // ReactionType -|------<- BlogReaction
        modelBuilder.Entity<ReactionType>()
            .HasMany(t => t.BlogReactions)
            .WithOne(r => r.ReactionType)
            .HasForeignKey(r => r.ReactionTypeId);

        // ReactionType -|------<- CommentReaction
        modelBuilder.Entity<ReactionType>()
            .HasMany(t => t.CommentReactions)
            .WithOne(r => r.ReactionType)
            .HasForeignKey(r => r.ReactionTypeId);

        /*
         * Seeding
         */
        modelBuilder.Entity<ReactionType>()
            .HasData(
                new ReactionType() { Id = Guid.Parse(ReactionTypeMapper.UPVOTE), Activity = "Upvote", Weightage = 2 },
                new ReactionType()
                    { Id = Guid.Parse(ReactionTypeMapper.DOWNVOTE), Activity = "Downvote", Weightage = -1 }
            );
    }
}