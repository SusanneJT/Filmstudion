﻿// <auto-generated />
using Filmstudion.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Filmstudion.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200204005054_movie-entity-changed")]
    partial class movieentitychanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Filmstudion.Data.Filmstudio", b =>
                {
                    b.Property<int>("FilmstudioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmstudioName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FilmstudioId");

                    b.ToTable("Filmstudios");
                });

            modelBuilder.Entity("Filmstudion.Data.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AvailableForLending")
                        .HasColumnType("bit");

                    b.Property<int>("MaxLendings")
                        .HasColumnType("int");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoryLine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
