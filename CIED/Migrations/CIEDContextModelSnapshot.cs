﻿// <auto-generated />
using System;
using CIED.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CIED.Migrations
{
    [DbContext(typeof(CIEDContext))]
    partial class CIEDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CIED.Models.Apunte", b =>
                {
                    b.Property<int>("ApunteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("EmpresaID");

                    b.Property<bool>("Estatus");

                    b.Property<DateTime>("Fecha");

                    b.Property<double>("Importe");

                    b.Property<int>("SlotID");

                    b.Property<int>("TipoApunteID");

                    b.HasKey("ApunteID");

                    b.HasIndex("EmpresaID");

                    b.HasIndex("SlotID");

                    b.HasIndex("TipoApunteID");

                    b.ToTable("Apunte");
                });

            modelBuilder.Entity("CIED.Models.Empresa", b =>
                {
                    b.Property<int>("EmpresaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Estatus");

                    b.HasKey("EmpresaID");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("CIED.Models.Slot", b =>
                {
                    b.Property<int>("SlotID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Estatus");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("Identificador");

                    b.Property<double>("Importe");

                    b.HasKey("SlotID");

                    b.ToTable("Slot");
                });

            modelBuilder.Entity("CIED.Models.TipoApunte", b =>
                {
                    b.Property<int>("TipoApunteID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Egreso");

                    b.Property<bool>("Estatus");

                    b.HasKey("TipoApunteID");

                    b.ToTable("TipoApunte");
                });

            modelBuilder.Entity("CIED.Models.Apunte", b =>
                {
                    b.HasOne("CIED.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CIED.Models.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("SlotID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CIED.Models.TipoApunte", "TipoApunte")
                        .WithMany()
                        .HasForeignKey("TipoApunteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
