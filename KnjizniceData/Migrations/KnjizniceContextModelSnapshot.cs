﻿// <auto-generated />
using KnjizniceData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace KnjizniceData.Migrations
{
    [DbContext(typeof(KnjizniceContext))]
    partial class KnjizniceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KnjizniceData.Models.Clan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<int?>("ClanskaIskaznicaId");

                    b.Property<DateTime>("DatRod");

                    b.Property<string>("Ime");

                    b.Property<string>("KontaktBroj");

                    b.Property<int?>("MaticnaKnjiznicaId");

                    b.Property<string>("Prezime");

                    b.HasKey("Id");

                    b.HasIndex("ClanskaIskaznicaId");

                    b.HasIndex("MaticnaKnjiznicaId");

                    b.ToTable("Clanovi");
                });

            modelBuilder.Entity("KnjizniceData.Models.ClanskaIskaznica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumIzdavanja");

                    b.Property<decimal>("Zakasnine");

                    b.HasKey("Id");

                    b.ToTable("ClanskeIskaznice");
                });

            modelBuilder.Entity("KnjizniceData.Models.GradjaKnjiznice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojPrimjeraka");

                    b.Property<decimal>("Cijena");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("GodinaIzdavanja");

                    b.Property<string>("ImageURL")
                        .IsRequired();

                    b.Property<int?>("LokacijaId");

                    b.Property<string>("Naslov")
                        .IsRequired();

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("LokacijaId");

                    b.HasIndex("StatusId");

                    b.ToTable("GradjaKnjiznice");

                    b.HasDiscriminator<string>("Discriminator").HasValue("GradjaKnjiznice");
                });

            modelBuilder.Entity("KnjizniceData.Models.Knjiznica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa")
                        .IsRequired();

                    b.Property<DateTime>("DatumOtvaranja");

                    b.Property<string>("ImageURL");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Opis");

                    b.Property<string>("Telefon")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Knjiznice");
                });

            modelBuilder.Entity("KnjizniceData.Models.Posudbe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClanskaIskaznicaId");

                    b.Property<DateTime>("Do");

                    b.Property<int>("GradjaKnjizniceId");

                    b.Property<DateTime>("Od");

                    b.HasKey("Id");

                    b.HasIndex("ClanskaIskaznicaId");

                    b.HasIndex("GradjaKnjizniceId");

                    b.ToTable("Posudbe");
                });

            modelBuilder.Entity("KnjizniceData.Models.PovijestPosudbi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClanskaIskaznicaId");

                    b.Property<int>("GradjaKnjizniceId");

                    b.Property<DateTime>("Posudjeno");

                    b.Property<DateTime?>("Vraceno");

                    b.HasKey("Id");

                    b.HasIndex("ClanskaIskaznicaId");

                    b.HasIndex("GradjaKnjizniceId");

                    b.ToTable("PovijestPosudbi");
                });

            modelBuilder.Entity("KnjizniceData.Models.RadnoVrijeme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DanTjedna");

                    b.Property<int?>("KnjiznicaId");

                    b.Property<int>("VrijemeOtvaranja");

                    b.Property<int>("VrijemeZatvaranja");

                    b.HasKey("Id");

                    b.HasIndex("KnjiznicaId");

                    b.ToTable("RadnoVrijeme");
                });

            modelBuilder.Entity("KnjizniceData.Models.Rezervacije", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClanskaIskaznicaId");

                    b.Property<int?>("GradjaKnjizniceId");

                    b.Property<DateTime>("Rezervirano");

                    b.HasKey("Id");

                    b.HasIndex("ClanskaIskaznicaId");

                    b.HasIndex("GradjaKnjizniceId");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("KnjizniceData.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.Property<string>("Opis")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Statusi");
                });

            modelBuilder.Entity("KnjizniceData.Models.Knjiga", b =>
                {
                    b.HasBaseType("KnjizniceData.Models.GradjaKnjiznice");

                    b.Property<string>("Autor")
                        .IsRequired();

                    b.Property<string>("ISBN")
                        .IsRequired();

                    b.ToTable("Knjiga");

                    b.HasDiscriminator().HasValue("Knjiga");
                });

            modelBuilder.Entity("KnjizniceData.Models.Video", b =>
                {
                    b.HasBaseType("KnjizniceData.Models.GradjaKnjiznice");

                    b.Property<string>("Redatelj")
                        .IsRequired();

                    b.ToTable("Video");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("KnjizniceData.Models.Clan", b =>
                {
                    b.HasOne("KnjizniceData.Models.ClanskaIskaznica", "ClanskaIskaznica")
                        .WithMany()
                        .HasForeignKey("ClanskaIskaznicaId");

                    b.HasOne("KnjizniceData.Models.Knjiznica", "MaticnaKnjiznica")
                        .WithMany("Clanovi")
                        .HasForeignKey("MaticnaKnjiznicaId");
                });

            modelBuilder.Entity("KnjizniceData.Models.GradjaKnjiznice", b =>
                {
                    b.HasOne("KnjizniceData.Models.Knjiznica", "Lokacija")
                        .WithMany("GradjaKnjiznice")
                        .HasForeignKey("LokacijaId");

                    b.HasOne("KnjizniceData.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KnjizniceData.Models.Posudbe", b =>
                {
                    b.HasOne("KnjizniceData.Models.ClanskaIskaznica", "ClanskaIskaznica")
                        .WithMany("Posudbe")
                        .HasForeignKey("ClanskaIskaznicaId");

                    b.HasOne("KnjizniceData.Models.GradjaKnjiznice", "GradjaKnjiznice")
                        .WithMany()
                        .HasForeignKey("GradjaKnjizniceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KnjizniceData.Models.PovijestPosudbi", b =>
                {
                    b.HasOne("KnjizniceData.Models.ClanskaIskaznica", "ClanskaIskaznica")
                        .WithMany()
                        .HasForeignKey("ClanskaIskaznicaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KnjizniceData.Models.GradjaKnjiznice", "GradjaKnjiznice")
                        .WithMany()
                        .HasForeignKey("GradjaKnjizniceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KnjizniceData.Models.RadnoVrijeme", b =>
                {
                    b.HasOne("KnjizniceData.Models.Knjiznica", "Knjiznica")
                        .WithMany()
                        .HasForeignKey("KnjiznicaId");
                });

            modelBuilder.Entity("KnjizniceData.Models.Rezervacije", b =>
                {
                    b.HasOne("KnjizniceData.Models.ClanskaIskaznica", "ClanskaIskaznica")
                        .WithMany()
                        .HasForeignKey("ClanskaIskaznicaId");

                    b.HasOne("KnjizniceData.Models.GradjaKnjiznice", "GradjaKnjiznice")
                        .WithMany()
                        .HasForeignKey("GradjaKnjizniceId");
                });
#pragma warning restore 612, 618
        }
    }
}