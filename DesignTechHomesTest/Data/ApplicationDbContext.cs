using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System;
using DesignTechHomesTest.Models;
using Microsoft.AspNetCore.Identity;

namespace DesignTechHomesTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        #region DbSet Properties

        public DbSet<Project> Projects { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ProjectNote> ProjectNotes { get; set; }

        public DbSet<ImageUpload> ImageUploads { get; set; }

        #endregion

        #region Constructors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Events

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Project entity configuration
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(256);
                entity.Property(p => p.CreatedBy).IsRequired().HasMaxLength(450);
                entity.Property(p => p.ModifiedBy).IsRequired().HasMaxLength(450);
                entity.Property(p => p.Budget).HasColumnType("decimal").HasPrecision(18, 6);
                entity.Property(p => p.AddressLine1).HasMaxLength(256);
                entity.Property(p => p.AddressLine2).HasMaxLength(256);
                entity.Property(p => p.City).HasMaxLength(100);
                entity.Property(p => p.State).HasMaxLength(100);
                entity.Property(p => p.PostalCode).HasMaxLength(30);

                //entity.HasOne(p => p.CreatedByUser).WithMany()
                //      .HasForeignKey(p => p.CreatedBy)
                //      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Client).WithMany(c => c.Projects)
                      .HasForeignKey(p => p.ClientId)
                      .OnDelete(DeleteBehavior.Restrict);

                //entity.HasOne(p => p.ModifiedByUser).WithMany()
                //      .HasForeignKey(p => p.ModifiedBy)
                //      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.ImageUploads).WithOne(i => i.Project)
                      .HasForeignKey(i => i.ProjectId).OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(p => p.ProjectNotes).WithOne(n => n.Project)
                      .HasForeignKey(n => n.ProjectId).OnDelete(DeleteBehavior.Cascade);
            });

            // Client entity configuration
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(c => c.LastName).IsRequired().HasMaxLength(100);
                entity.Property(c => c.AddressLine1).HasMaxLength(256);
                entity.Property(c => c.AddressLine2).HasMaxLength(256);
                entity.Property(c => c.City).HasMaxLength(100);
                entity.Property(c => c.State).HasMaxLength(100);
                entity.Property(c => c.PostalCode).HasMaxLength(30);
                entity.Property(c => c.EmailAddress).HasMaxLength(256);
                entity.Property(c => c.PhoneNumber).HasMaxLength(30);

                entity.HasMany(c => c.Projects).WithOne(p => p.Client)
                      .HasForeignKey(p => p.ClientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            //// ProjectNote entity configuration
            //modelBuilder.Entity<ProjectNote>(entity =>
            //{
            //    entity.HasKey(n => n.Id);
            //    entity.Property(n => n.Note).IsRequired();

            //    entity.HasOne(n=> n.Project).WithMany(p => p.ProjectNotes)
            //          .HasForeignKey(n => n.ProjectId)
            //          .OnDelete(DeleteBehavior.Restrict);
            //});

            //// ImageUpload entity configuration
            //modelBuilder.Entity<ImageUpload>(entity =>
            //{
            //    entity.HasKey(n => n.Id);
            //    entity.Property(i => i.ImageData).IsRequired();

            //    entity.HasOne(i => i.Project).WithMany(p => p.ImageUploads)
            //          .HasForeignKey(i => i.ProjectId)
            //          .OnDelete(DeleteBehavior.Restrict);
            //});
        }

        #endregion
    }
}