﻿// <auto-generated />
using System;
using MaMovieDB.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MaMovieDB.Migrations
{
    [DbContext(typeof(FilmsDBContext))]
    partial class FilmsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MaMovieDB.Models.EntityFramework.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("flm_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FilmId"));

                    b.Property<DateTime?>("DateSortie")
                        .HasColumnType("date")
                        .HasColumnName("flm_datesortie");

                    b.Property<decimal?>("Duree")
                        .HasMaxLength(3)
                        .HasColumnType("numeric(3,0)")
                        .HasColumnName("flm_duree");

                    b.Property<string>("Genre")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("flm_genre");

                    b.Property<string>("Resume")
                        .HasColumnType("text")
                        .HasColumnName("flm_resume");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("flm_titre");

                    b.HasKey("FilmId");

                    b.ToTable("t_e_film_flm");
                });

            modelBuilder.Entity("MaMovieDB.Models.EntityFramework.Notation", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("flm_id");

                    b.Property<int>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    b.Property<int?>("Note")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("not_note");

                    b.HasKey("FilmId", "UtilisateurId")
                        .HasName("pk_notations");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("t_j_notation_not");

                    b.HasCheckConstraint("ck_not_note", "not_note between 0 and 5");
                });

            modelBuilder.Entity("MaMovieDB.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UtilisateurId"));

                    b.Property<string>("CodePostal")
                        .HasColumnType("char(5)")
                        .HasColumnName("utl_cp");

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("ult_datecreation")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_latitude");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_longitude");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("utl_mail");

                    b.Property<string>("Mobile")
                        .HasColumnType("char(10)")
                        .HasColumnName("utl_mobile");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_nom");

                    b.Property<string>("Pays")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasDefaultValue("France")
                        .HasColumnName("utl_pays");

                    b.Property<string>("Prenom")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_prenom");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("utl_pwd");

                    b.Property<string>("Rue")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("utl_rue");

                    b.Property<string>("Ville")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("utl_ville");

                    b.HasKey("UtilisateurId");

                    b.HasIndex("Mail")
                        .IsUnique();

                    b.ToTable("t_e_utilisateur_utl");
                });

            modelBuilder.Entity("MaMovieDB.Models.EntityFramework.Notation", b =>
                {
                    b.HasOne("MaMovieDB.Models.EntityFramework.Film", "FilmNote")
                        .WithMany("NotesFilm")
                        .HasForeignKey("FilmId")
                        .IsRequired()
                        .HasConstraintName("fk_not_flm");

                    b.HasOne("MaMovieDB.Models.EntityFramework.Utilisateur", "UtilisateurNotant")
                        .WithMany("NotesUtilisateur")
                        .HasForeignKey("UtilisateurId")
                        .IsRequired()
                        .HasConstraintName("fk_not_utl");

                    b.Navigation("FilmNote");

                    b.Navigation("UtilisateurNotant");
                });

            modelBuilder.Entity("MaMovieDB.Models.EntityFramework.Film", b =>
                {
                    b.Navigation("NotesFilm");
                });

            modelBuilder.Entity("MaMovieDB.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Navigation("NotesUtilisateur");
                });
#pragma warning restore 612, 618
        }
    }
}
