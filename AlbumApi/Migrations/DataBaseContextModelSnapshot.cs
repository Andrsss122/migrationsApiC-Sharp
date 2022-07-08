﻿// <auto-generated />
using System;
using AlbumApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlbumApi.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AlbumApi.Data.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<int?>("artistaIdArtista")
                        .HasColumnType("int");

                    b.Property<int?>("generoIdGenero")
                        .HasColumnType("int");

                    b.HasKey("IdAlbum");

                    b.HasIndex("artistaIdArtista");

                    b.HasIndex("generoIdGenero");

                    b.ToTable("album");
                });

            modelBuilder.Entity("AlbumApi.Data.Artista", b =>
                {
                    b.Property<int>("IdArtista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("IdArtista");

                    b.ToTable("artista");
                });

            modelBuilder.Entity("AlbumApi.Data.Genero", b =>
                {
                    b.Property<int>("IdGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("IdGenero");

                    b.ToTable("genero");
                });

            modelBuilder.Entity("AlbumApi.Data.Album", b =>
                {
                    b.HasOne("AlbumApi.Data.Artista", "artista")
                        .WithMany()
                        .HasForeignKey("artistaIdArtista");

                    b.HasOne("AlbumApi.Data.Genero", "genero")
                        .WithMany()
                        .HasForeignKey("generoIdGenero");
                });
#pragma warning restore 612, 618
        }
    }
}
