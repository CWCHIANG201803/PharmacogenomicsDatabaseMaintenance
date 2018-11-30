using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pharmacogenomicsManagement.Models
{
    public partial class pharmcogeneContext : DbContext
    {
        public pharmcogeneContext()
        {
        }

        public pharmcogeneContext(DbContextOptions<pharmcogeneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diplotype> Diplotype { get; set; }
        public virtual DbSet<Drug> Drug { get; set; }
        public virtual DbSet<DrugDescription> DrugDescription { get; set; }
        public virtual DbSet<Gene> Gene { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=nana;Database=pharmcogene;Trusted_Connection=True;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diplotype>(entity =>
            {
                entity.Property(e => e.DiplotypeId).ValueGeneratedNever();

                entity.Property(e => e.Diplotype1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Diplotype2)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Gene)
                    .WithMany(p => p.Diplotype)
                    .HasForeignKey(d => d.GeneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GENENAME_DIPLOTYPE_GENE_LIST1");
            });

            modelBuilder.Entity<Drug>(entity =>
            {
                entity.HasKey(e => e.AtcCode);

                entity.Property(e => e.AtcCode)
                    .HasColumnName("ATC_CODE")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.DrugName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DrugDescription>(entity =>
            {
                entity.HasKey(e => new { e.DiplotypeId, e.AtcCode });

                entity.Property(e => e.AtcCode)
                    .HasColumnName("ATC_CODE")
                    .HasMaxLength(50);

                entity.Property(e => e.ActivityScore)
                    .HasColumnName("ACTIVITY_SCORE")
                    .HasMaxLength(100);

                entity.Property(e => e.Alternative)
                    .HasColumnName("ALTERNATIVE")
                    .HasColumnType("ntext");

                entity.Property(e => e.ClassificationOfRecommendations)
                    .HasColumnName("CLASSIFICATION_OF_RECOMMENDATIONS")
                    .HasColumnType("ntext");

                entity.Property(e => e.Message)
                    .HasColumnName("MSG")
                    .HasColumnType("ntext");

                entity.Property(e => e.Phenotype)
                    .HasColumnName("PHENOTYPE")
                    .HasColumnType("ntext");

                entity.Property(e => e.TherapeuticRecommendations)
                    .HasColumnName("THERAPEUTIC_RECOMMENDATIONS")
                    .HasColumnType("ntext");

                entity.HasOne(d => d.AtcCodeNavigation)
                    .WithMany(p => p.DrugDescription)
                    .HasForeignKey(d => d.AtcCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicine_Description_Medicine_List");

                entity.HasOne(d => d.Diplotype)
                    .WithMany(p => p.DrugDescription)
                    .HasForeignKey(d => d.DiplotypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDICINE_DESCRIPTION_GENENAME_DIPLOTYPE1");
            });

            modelBuilder.Entity<Gene>(entity =>
            {
                entity.Property(e => e.GeneId).ValueGeneratedNever();

                entity.Property(e => e.GeneName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
