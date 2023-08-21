using System;
using System.Collections.Generic;
using EntityFramework_Benchmark.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EntityFramework_Benchmark.Settings;

public partial class BenchmarkDbContext : DbContext
{
    public BenchmarkDbContext()
    {
    }

    public BenchmarkDbContext(DbContextOptions<BenchmarkDbContext> options)
        : base(options)
    {
    }

    private readonly StreamWriter _logStream = new StreamWriter("../../../mylog.txt", append: true);

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=127.0.0.1;port=3308;uid=root;pwd=root;database=diplomski", ServerVersion.Parse("8.0.34-mysql"));
        optionsBuilder.LogTo(_logStream.WriteLine, new[] { DbLoggerCategory.Query.Name });
    }

    public override void Dispose()
    {
        base.Dispose();
        _logStream.Dispose();
    }

    public override async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();
        await _logStream.DisposeAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.PostId)
                .ValueGeneratedNever()
                .HasColumnName("post_id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.Timestamp)
                .HasColumnType("timestamp")
                .HasColumnName("timestamp");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Posts_ibfk_1");

            entity.HasMany(d => d.Tags).WithMany(p => p.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Post_Tags_ibfk_2"),
                    l => l.HasOne<Post>().WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Post_Tags_ibfk_1"),
                    j =>
                    {
                        j.HasKey("PostId", "TagId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("Post_Tags");
                        j.HasIndex(new[] { "TagId" }, "tag_id");
                        j.IndexerProperty<int>("PostId").HasColumnName("post_id");
                        j.IndexerProperty<int>("TagId").HasColumnName("tag_id");
                    });
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PRIMARY");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.ProfileId)
                .ValueGeneratedNever()
                .HasColumnName("profile_id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Bio)
                .HasMaxLength(500)
                .HasColumnName("bio");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Profiles_ibfk_1");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PRIMARY");

            entity.Property(e => e.TagId)
                .ValueGeneratedNever()
                .HasColumnName("tag_id");
            entity.Property(e => e.TagName)
                .HasMaxLength(50)
                .HasColumnName("tag_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
