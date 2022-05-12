using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APILab.Models
{
    public partial class Project_BBBContext : DbContext
    {

        public Project_BBBContext()
        {
        }

        public Project_BBBContext(DbContextOptions<Project_BBBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=163.178.173.148;Initial Catalog=Project_BBB;User ID=lenguajes;Password=lg.2022zx");////no deberia de estar aqui si no como en los laboratorios
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IDrol);

                entity.ToTable("Rol");

                entity.Property(e => e.IDrol).ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasKey(e => e.IDuser);

                entity.Property(e => e.IDuser).HasColumnName("IDuser").GetType();

                entity.Property(e => e.IDrol).HasColumnName("IDrol").GetType();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.DNI).HasMaxLength(25);

                entity.Property(e => e.Age).HasColumnName("Age").GetType();

                entity.Property(e => e.Telephone).HasMaxLength(25);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
