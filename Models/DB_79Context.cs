using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _79_Project.Models
{
    public partial class DB_79Context : DbContext
    {
        public DB_79Context()
        {
        }

        public DB_79Context(DbContextOptions<DB_79Context> options)
            : base(options)
        {
        }

        public virtual DbSet<SP_Report1> SP_Report1 { get; set; }
        public virtual DbSet<SP_Report2> SP_Report2 { get; set; }
        public virtual DbSet<TblMAdditional> TblMAdditional { get; set; }
        public virtual DbSet<TblMNasabah> TblMNasabah { get; set; }
        public virtual DbSet<TblTPembayaran> TblTPembayaran { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OLC72DS;Database=DB_79;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<TblMAdditional>(entity =>
            {
                entity.ToTable("TblM_Additional");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Group)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMNasabah>(entity =>
            {
                entity.ToTable("TblM_Nasabah");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DelDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblTPembayaran>(entity =>
            {
                entity.ToTable("TblT_Pembayaran");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DelDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblTPembayaran)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblT_Pembayaran_TblM_Nasabah");
            });
        }
    }
}
