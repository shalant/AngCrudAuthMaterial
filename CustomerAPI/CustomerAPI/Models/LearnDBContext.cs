using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerAPI.Models
{
    public partial class LearnDBContext : DbContext
    {
        public LearnDBContext()
        {
        }

        public LearnDBContext(DbContextOptions<LearnDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;
        public virtual DbSet<TblRefreshtoken> TblRefreshtokens { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DOUGDELL22\\SQLEXPRESS;Database=LearnDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_customer");

                entity.Property(e => e.Email)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblRefreshtoken>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_refreshtoken");

                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TokenId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_user");

                entity.Property(e => e.Email)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
