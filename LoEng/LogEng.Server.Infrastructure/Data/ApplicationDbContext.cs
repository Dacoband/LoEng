using System;
using System.Collections.Generic;
using LoEng.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LogEng.Server.Infrastructure.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Example> Examples { get; set; }
    public virtual DbSet<Level> Levels { get; set; }
    public virtual DbSet<Synonym> Synonyms { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<Topic> Topics { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserWord> UserWords { get; set; }
    public virtual DbSet<Word> Words { get; set; }
    public virtual DbSet<WordTag> WordTags { get; set; }
    public virtual DbSet<WordType> WordTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }

    private string? GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionStringDB"];
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Cấu hình Example
        modelBuilder.Entity<Example>(entity =>
        {
            entity.HasKey(e => e.ExampleId).HasName("PK__Examples__C464770951EE04F1");
            entity.Property(e => e.ExampleId).HasDefaultValueSql("NEWID()"); // Tự động sinh GUID
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelFlg).HasDefaultValue(false);
            entity.Property(e => e.EnglishExample).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VietnameseMeaning).HasMaxLength(500);

            entity.HasOne(d => d.Word).WithMany(p => p.Examples)
                .HasForeignKey(d => d.WordId)
                .HasConstraintName("FK__Examples__WordId__440B1D61");
        });

        // Cấu hình Level
        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.LevelId).HasName("PK__Levels__09F03C2652B547E7");
            entity.Property(e => e.LevelId).HasDefaultValueSql("NEWID()"); // Tự động sinh GUID
            entity.HasIndex(e => e.LevelName, "UQ_LevelName").IsUnique();

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelFlg).HasDefaultValue(false);
            entity.Property(e => e.LevelName).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        // Cấu hình Synonym
        modelBuilder.Entity<Synonym>(entity =>
        {
            entity.HasKey(e => e.SynonymId).HasName("PK__Synonyms__066F6383DFAD1011");
            entity.Property(e => e.SynonymId).HasDefaultValueSql("NEWID()"); // Tự động sinh GUID

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelFlg).HasDefaultValue(false);
            entity.Property(e => e.SynonymWord).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Word).WithMany(p => p.Synonyms)
                .HasForeignKey(d => d.WordId)
                .HasConstraintName("FK__Synonyms__WordId__412EB0B6");
        });

        // Cấu hình Tag
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tags__657CF9ACBF3CA37D");
            entity.Property(e => e.TagId).HasDefaultValueSql("NEWID()"); // Tự động sinh GUID

            entity.HasIndex(e => e.TagName, "UQ_TagName").IsUnique();

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelFlg).HasDefaultValue(false);
            entity.Property(e => e.TagName).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        // Cấu hình Topic
        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topics__022E0F5D1E796FE7");
            entity.Property(e => e.TopicId).HasDefaultValueSql("NEWID()"); // Tự động sinh GUID

            entity.HasIndex(e => e.TopicName, "UQ_TopicName").IsUnique();

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelFlg).HasDefaultValue(false);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.TopicName).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        // Cấu hình User
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CC332DD18");
            entity.Property(e => e.UserId).HasDefaultValueSql("NEWID()"); // Tự động sinh GUID

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelFlg).HasDefaultValue(false);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        // Cấu hình UserWord
        modelBuilder.Entity<UserWord>(entity =>
        {
            entity.HasKey(e => e.UserWordId).HasName("PK__UserWord__6E1BC12F8BAFDCC2");
            entity.Property(e => e.UserWordId).HasDefaultValueSql("NEWID()"); // Tự động sinh GUID

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelFlg).HasDefaultValue(false);
            entity.Property(e => e.IsLearned).HasDefaultValue(false);
            entity.Property(e => e.LastReviewedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Level).WithMany(p => p.UserWords)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK__UserWords__Level__7E37BEF6");

            entity.HasOne(d => d.User).WithMany(p => p.UserWords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserWords__UserI__49C3F6B7");

            entity.HasOne(d => d.Word).WithMany(p => p.UserWords)
                .HasForeignKey(d => d.WordId)
                .HasConstraintName("FK__UserWords__WordI__4AB81AF0");
        });

        // Cấu hình Word
        modelBuilder.Entity<Word>(entity =>
        {
            entity.HasKey(e => e.WordId).HasName("PK__Words__2C20F066D1723C41");
            entity.Property(e => e.WordId).HasDefaultValueSql("NEWID()"); // Tự động sinh GUID

            entity.HasIndex(e => e.EnglishWord, "UQ_EnglishWord").IsUnique();

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelFlg).HasDefaultValue(false);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EnglishWord).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.Pronunciation).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VietnameseMeaning).HasMaxLength(200);

            entity.HasOne(d => d.Level).WithMany(p => p.Words)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK__Words__LevelId__7D439ABD");

            entity.HasOne(d => d.Topic).WithMany(p => p.Words)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__Words__TopicId__3B75D760");

            entity.HasOne(d => d.WordType).WithMany(p => p.Words)
                .HasForeignKey(d => d.WordTypeId)
                .HasConstraintName("FK__Words__WordTypeI__3C69FB99");
        });

        // Cấu hình WordTag
        modelBuilder.Entity<WordTag>(entity =>
        {
            entity.HasKey(e => e.WordTagId).HasName("PK__WordTags__953D460CBC7084D6");
            entity.Property(e => e.WordTagId).HasDefaultValueSql("NEWID()"); // Tự động sinh GUID

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelFlg).HasDefaultValue(false);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Tag).WithMany(p => p.WordTags)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("FK__WordTags__TagId__534D60F1");

            entity.HasOne(d => d.Word).WithMany(p => p.WordTags)
                .HasForeignKey(d => d.WordId)
                .HasConstraintName("FK__WordTags__WordId__52593CB8");
        });

        // Cấu hình WordType
        modelBuilder.Entity<WordType>(entity =>
        {
            entity.HasKey(e => e.WordTypeId).HasName("PK__WordType__C3532AAD5FA35DB9");
            entity.Property(e => e.WordTypeId).HasDefaultValueSql("NEWID()"); // Tự động sinh GUID

            entity.HasIndex(e => e.TypeName, "UQ_TypeName").IsUnique();

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DelFlg).HasDefaultValue(false);
            entity.Property(e => e.TypeName).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}