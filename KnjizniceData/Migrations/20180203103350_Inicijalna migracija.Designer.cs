﻿// <auto-generated />
using KnjizniceData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace KnjizniceData.Migrations
{
    [DbContext(typeof(KnjizniceContext))]
    [Migration("20180203103350_Inicijalna migracija")]
    partial class Inicijalnamigracija
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("DatRod");

                    b.Property<string>("Ime");

                    b.Property<string>("KontaktBroj");

                    b.Property<string>("Prezime");

                    b.HasKey("Id");

                    b.ToTable("Clanovi");
                });
#pragma warning restore 612, 618
        }
    }
}
