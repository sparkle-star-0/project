using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace shokouhWebSite.Models;

public partial class ShokouhContext : DbContext
{
    public ShokouhContext()
    {
    }

    public ShokouhContext(DbContextOptions<ShokouhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<CommunicationTable> CommunicationTables { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<PositionTable> PositionTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\MYSQLSERVER2022;Database=shokouh;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("admins");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.PositionNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.Position)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_admins_positionTable");
        });

        modelBuilder.Entity<CommunicationTable>(entity =>
        {
            entity.ToTable("communicationTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Receiver)
                .HasComment("who receiver message ? {accounting 0 ,voiceOfCustomer 1 , commercialUnit 2 }")
                .HasColumnName("receiver");
            entity.Property(e => e.SenderEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senderEmail");
            entity.Property(e => e.TextMessage)
                .HasColumnType("text")
                .HasColumnName("textMessage");
            entity.Property(e => e.Topic)
                .HasMaxLength(50)
                .HasColumnName("topic");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("images");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Image1).HasColumnName("image");
            entity.Property(e => e.ImageName)
                .HasMaxLength(50)
                .HasColumnName("imageName");
            entity.Property(e => e.Tag)
                .HasComment("what image type? {logo 0 , regular 1 , products 2}")
                .HasColumnName("tag");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("menuItems");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LinkItem)
                .IsUnicode(false)
                .HasColumnName("linkItem");
            entity.Property(e => e.Tag)
                .HasComment("what is item of menu type?{regular 0 , admin 1}")
                .HasColumnName("tag");
            entity.Property(e => e.TitleItem)
                .HasMaxLength(50)
                .HasColumnName("titleItem");
        });

        modelBuilder.Entity<PositionTable>(entity =>
        {
            entity.ToTable("positionTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasComment("xxx =>( user type{ head admin 1, admin 2 , other 3 } / acsses level {high 1 , meduim 2 , low 3} / position{accounting 1 , Commercial Department 2 , voice of customer 3 }  )")
                .HasColumnName("code");
            entity.Property(e => e.PositionName)
                .HasMaxLength(100)
                .HasColumnName("positionName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
