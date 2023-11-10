﻿// <auto-generated />
using System;
using AmandaViagens.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmandaViagens.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231110150421_criando-banco")]
    partial class criandobanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AmandaViagens.Models.Cruzeiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<decimal?>("Preco")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.ToTable("Cruzeiro");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "América do Sul<br>7 Noites<br>Saindo de: Santos (São Paulo) <br>Porto de desembarque: Santos (São Paulo)",
                            Image = "images/cruzerios/offer_1.jpg",
                            Nome = "",
                            Preco = 4646.25m
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "América do Sul<br>9 Dias<br>Saindo de: Rio de Janeiro (Rio de Janeiro)<br>Porto de desembarque: Rio de Janeiro (Rio de Janeiro)",
                            Image = "images/cruzerios/offer_2.jpg",
                            Nome = "",
                            Preco = 3463.00m
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Pacífico Sul: Kauai & Moorea<br>12 Dias<br>Saindo de: Honolulu, Oahu<br>Porto de desembarque: Papeete, Taiti, Polinésia Francesa",
                            Image = "images/cruzerios/offer_3.jpg",
                            Nome = "",
                            Preco = 3463.00m
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Bahamas & Perfect Day Cruise<br>3 Noites<br>Saindo de: Fort Lauderdale, Flórida<br>Porto de desembarque: Fort Lauderdale, Flórida",
                            Image = "images/cruzerios/offer_4.jpg",
                            Nome = "",
                            Preco = 941.00m
                        });
                });

            modelBuilder.Entity("AmandaViagens.Models.Ingresso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.ToTable("Ingresso");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "INGRESSOS PARA OS PARQUES TEMÁTICOS WALT DISNEY WORLD<br>1 Dia (10 anos ou mais)",
                            Image = "images/ingressos/castelo.jpg",
                            Nome = "Walt Disney World",
                            Preco = 548.76m
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "PASSAPORTE DE ACESSO 1º LOTE<br>1 Dia (A partir de 05 anos)",
                            Image = "images/ingressos/beto.jpg",
                            Nome = "Beto Carrero World",
                            Preco = 139.90m
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "INGRESSO DIÁRIO INTEIRA OUTUBRO E NOVEMBRO 2023<br>1 Dia",
                            Image = "images/ingressos/thermas.jpg",
                            Nome = "Thermas dos Laranjais",
                            Preco = 150.00m
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "HORA DO HORROR<br>1 Dia",
                            Image = "images/ingressos/hopihari.jpg",
                            Nome = "Hopi Hari",
                            Preco = 159.90m
                        });
                });

            modelBuilder.Entity("AmandaViagens.Models.PontoTuristico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Icone")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Image")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("PontoTuristico");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Rio de Janeiro<br>De braços abertos sobre a Guanabara, o Cristo Redentor recebe os visitantes e abençoa os cariocas.",
                            Icone = "images/backpack.png",
                            Image = "images/pontos/cristo.jpg",
                            Nome = "Cristo Redentor"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Paris<br>Esta joia da paisagem parisiense e símbolo máximo da França fica ainda mais espetacular quando vista de perto.",
                            Icone = "images/backpack.png",
                            Image = "images/pontos/torre.jpg",
                            Nome = "Torre Eiffel"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "República Dominicana<br>A tropical Punta Cana se orgulha de ser um dos melhores destinos do Caribe, e sua fama é, de fato, justificada.",
                            Icone = "images/island_t.png",
                            Image = "images/pontos/praia.jpg",
                            Nome = "Punta Cana"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Rio Grande do Sul<br>Romântica, charmosa, cheia de cultura, belas paisagens, atrações e ótima culinária.",
                            Icone = "images/backpack.png",
                            Image = "images/pontos/sul.jpg",
                            Nome = "Gramado"
                        });
                });

            modelBuilder.Entity("AmandaViagens.Models.Usuario", b =>
                {
                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Foto")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            UsuarioId = "5c50c1ef-b242-4973-b276-eaf93b4e798a",
                            Foto = "/img/users/avatar.png",
                            Nome = "Marina Porfirio"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2387f71c-9988-4fc1-bfcf-df88d1531a6a",
                            ConcurrencyStamp = "66c68302-7c74-4df4-b44c-86046a8eb3a0",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "fc3e3b06-b9b4-49c7-977d-5f81c48b4b00",
                            ConcurrencyStamp = "1b1fbde8-8056-40f3-8162-23a4a8c2cc8c",
                            Name = "Funcionário",
                            NormalizedName = "FUNCIONARIO"
                        },
                        new
                        {
                            Id = "b1d11fff-ca32-4358-b5ed-5966dbb9a7b0",
                            ConcurrencyStamp = "afc955a3-4ebd-4f83-ada0-56186df99faa",
                            Name = "Cliente",
                            NormalizedName = "CLIENTE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "5c50c1ef-b242-4973-b276-eaf93b4e798a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3318b928-6470-4305-bbd9-4a00f0bab875",
                            Email = "admin@viagens.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@VIAGENS.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEKzc9O/DZ9oM4MoD0a/yviJdeb2Cng02/gaJvm1asXBsDNAyLlOqcGgoT3R8tlan4A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6a08ecb1-5473-43de-9d4a-fec0924afaa0",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "5c50c1ef-b242-4973-b276-eaf93b4e798a",
                            RoleId = "2387f71c-9988-4fc1-bfcf-df88d1531a6a"
                        },
                        new
                        {
                            UserId = "5c50c1ef-b242-4973-b276-eaf93b4e798a",
                            RoleId = "fc3e3b06-b9b4-49c7-977d-5f81c48b4b00"
                        },
                        new
                        {
                            UserId = "5c50c1ef-b242-4973-b276-eaf93b4e798a",
                            RoleId = "b1d11fff-ca32-4358-b5ed-5966dbb9a7b0"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AmandaViagens.Models.Usuario", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "AcocountUser")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcocountUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
