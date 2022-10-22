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
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_customer");

                entity.Property(e => e.Addy)
                    .HasMaxLength(10)
                    .HasColumnName("addy")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblRefreshtoken>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_refreshtoken");

                entity.Property(e => e.Token)
                    .HasMaxLength(10)
                    .HasColumnName("token")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_user");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasColumnType("numeric(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
