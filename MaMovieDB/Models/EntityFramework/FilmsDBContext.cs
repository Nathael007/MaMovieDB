using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace MaMovieDB.Models.EntityFramework
{
    public partial class FilmsDBContext : DbContext
    {
        public FilmsDBContext() { }

        public FilmsDBContext(DbContextOptions<FilmsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Film> Film { get; set; } = null!;
        public virtual DbSet<Notation> Notation { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateur { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notation>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.UtilisateurId })
                    .HasName("pk_notations");

                entity.HasOne(d => d.FilmNote)
                    .WithMany(p => p.NotesFilm)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_not_flm");

                entity.HasOne(d => d.UtilisateurNotant)
                    .WithMany(p => p.NotesUtilisateur)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_not_utl");

                entity.HasCheckConstraint("ck_not_note", "not_note between 0 and 5");
            });
            modelBuilder.Entity<Utilisateur>().Property(b => b.Pays).HasDefaultValue("France");
            modelBuilder.Entity<Utilisateur>().HasIndex(b => b.Mail).IsUnique();
            modelBuilder.Entity<Utilisateur>().Property(b => b.DateCreation).HasDefaultValueSql("CURRENT_DATE");
            //modelBuilder.Entity<Notation>().Property(b => b.Note);
            modelBuilder.Entity<Film>().Property(b => b.Duree).HasMaxLength(3);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
