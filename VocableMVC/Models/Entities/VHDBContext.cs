using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VocableMVC.Models.Entities
{
    public partial class VHDBContext : DbContext
    {
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=tcp:westeuropevhdbsqlserver.database.windows.net,1433; Initial Catalog=vhdb; Persist Security Info=False; User ID=vhdbadmin; Password=niklas23serutsom34!; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("Categories", "voc");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.ToTable("Dictionary", "voc");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.JoinId).HasColumnName("JoinID");

                entity.Property(e => e.Lid).HasColumnName("LID");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Dictionary)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Dictionary__CID__3C69FB99");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Dictionary)
                    .HasForeignKey(d => d.Lid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Dictionary__LID__3E52440B");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Dictionary)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Dictionary__UID__3D5E1FD2");
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.ToTable("Languages", "voc");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "voc");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}