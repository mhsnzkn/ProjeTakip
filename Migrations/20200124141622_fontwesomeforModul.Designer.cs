﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjeYonetim.Data;

namespace ProjeYonetim.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200124141622_fontwesomeforModul")]
    partial class fontwesomeforModul
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjeYonetim.Models.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasMaxLength(50);

                    b.Property<string>("Role")
                        .HasMaxLength(10);

                    b.Property<string>("Username")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Kullanici");
                });

            modelBuilder.Entity("ProjeYonetim.Models.Modul", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .HasMaxLength(100);

                    b.Property<string>("Fontawesome")
                        .HasMaxLength(100);

                    b.Property<int>("ProjeId");

                    b.Property<int>("Sira");

                    b.HasKey("Id");

                    b.HasIndex("ProjeId");

                    b.ToTable("Moduller");
                });

            modelBuilder.Entity("ProjeYonetim.Models.Proje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Projeler");
                });

            modelBuilder.Entity("ProjeYonetim.Models.Rapor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasMaxLength(300);

                    b.Property<string>("Adi")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CrtDate");

                    b.Property<int>("ModulId");

                    b.Property<int>("ProjeId");

                    b.Property<int>("RaporTurId");

                    b.Property<int>("Sira");

                    b.Property<DateTime>("Tarih");

                    b.HasKey("Id");

                    b.HasIndex("ModulId");

                    b.HasIndex("ProjeId");

                    b.HasIndex("RaporTurId");

                    b.ToTable("Raporlar");
                });

            modelBuilder.Entity("ProjeYonetim.Models.RaporTur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasMaxLength(400);

                    b.Property<string>("Adi")
                        .HasMaxLength(100);

                    b.Property<int>("ModulId");

                    b.Property<int>("ProjeId");

                    b.Property<int>("Sira");

                    b.HasKey("Id");

                    b.HasIndex("ModulId");

                    b.HasIndex("ProjeId");

                    b.ToTable("RaporTurleri");
                });

            modelBuilder.Entity("ProjeYonetim.Models.Modul", b =>
                {
                    b.HasOne("ProjeYonetim.Models.Proje", "Proje")
                        .WithMany()
                        .HasForeignKey("ProjeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjeYonetim.Models.Rapor", b =>
                {
                    b.HasOne("ProjeYonetim.Models.Modul", "Modul")
                        .WithMany()
                        .HasForeignKey("ModulId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjeYonetim.Models.Proje", "Proje")
                        .WithMany()
                        .HasForeignKey("ProjeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjeYonetim.Models.RaporTur", "RaporTur")
                        .WithMany()
                        .HasForeignKey("RaporTurId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjeYonetim.Models.RaporTur", b =>
                {
                    b.HasOne("ProjeYonetim.Models.Modul", "Modul")
                        .WithMany()
                        .HasForeignKey("ModulId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjeYonetim.Models.Proje", "Proje")
                        .WithMany()
                        .HasForeignKey("ProjeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
