using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementSystem.Models;

public partial class CrmdatabaseContext : DbContext
{
    public CrmdatabaseContext()
    {
    }

    public CrmdatabaseContext(DbContextOptions<CrmdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Interaction> Interactions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=USHYDADARSKUM7;Database=CRMDatabase;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB8559D20286");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerAssgAgentId).HasColumnName("customer_assg_agent_id");
            entity.Property(e => e.CustomerContactDetails)
                .HasColumnType("text")
                .HasColumnName("customer_contact_details");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_email");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customer_phone");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Interaction>(entity =>
        {
            entity.HasKey(e => e.InteractionId).HasName("PK__Interact__605F8FE6596B72B5");

            entity.Property(e => e.InteractionId)
                .ValueGeneratedNever()
                .HasColumnName("interaction_id");
            entity.Property(e => e.InteractionDate)
                .HasColumnType("datetime")
                .HasColumnName("interaction_date");
            entity.Property(e => e.InteractionDetails)
                .HasColumnType("text")
                .HasColumnName("interaction_details");
            entity.Property(e => e.InteractionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("interaction_type");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Interactions)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Interacti__ticke__4222D4EF");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__47027DF5FC42DA1F");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_id");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.FeedbackReview)
                .HasColumnType("text")
                .HasColumnName("feedback_review");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("rating");
            entity.Property(e => e.Recommendation)
                .HasColumnType("text")
                .HasColumnName("recommendation");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__D596F96B37C601F0");

            entity.Property(e => e.TicketId)
                .ValueGeneratedNever()
                .HasColumnName("ticket_id");
            entity.Property(e => e.ActionRemarks)
                .HasColumnType("text")
                .HasColumnName("action_remarks");
            entity.Property(e => e.AgentId).HasColumnName("agent_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Agent).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK__Tickets__agent_i__3F466844");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Tickets__custome__3D5E1FD2");

            entity.HasOne(d => d.Product).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Tickets__product__3E52440B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370FFE0E833D");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_name");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
