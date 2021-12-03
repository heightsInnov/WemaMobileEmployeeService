using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WemaMobileEmployeeService.Models
{
    public partial class WemaMobileTrainingContext : DbContext
    {
        public WemaMobileTrainingContext()
        {
        }

        public WemaMobileTrainingContext(DbContextOptions<WemaMobileTrainingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BitDepartment> BitDepartments { get; set; }
        public virtual DbSet<BitEmployee> BitEmployees { get; set; }
        public virtual DbSet<BitEmployeePicture> BitEmployeePictures { get; set; }
        public virtual DbSet<BitState> BitStates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Wema_BIT");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BitDepartment>(entity =>
            {
                entity.ToTable("BIT_Department");

                entity.Property(e => e.Department).HasMaxLength(50);
            });

            modelBuilder.Entity<BitEmployee>(entity =>
            {
                entity.ToTable("BIT_Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("('USER')");

                entity.HasOne(d => d.DepartmentNavigation)
                    .WithMany(p => p.BitEmployees)
                    .HasForeignKey(d => d.Department)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BIT_Employee_BIT_Department");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.BitEmployees)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK_BIT_Employee_BIT_State");
            });

            modelBuilder.Entity<BitEmployeePicture>(entity =>
            {
                entity.ToTable("BIT_EmployeePictures");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UploadLink)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.BitEmployeePictures)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BIT_EmployeePictures_BIT_Employee");
            });

            modelBuilder.Entity<BitState>(entity =>
            {
                entity.ToTable("BIT_State");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
