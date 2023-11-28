using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AmandaViagens.Models;

namespace AmandaViagens.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        #region Cruzeiros
        List<Cruzeiro> cruzeiros = new() {
            new() {
                Id = 1,
                Nome = "Msc Preziosa",
                Descricao = "América do Sul<br>7 Noites<br>Saindo de: Santos (São Paulo) <br>Porto de desembarque: Santos (São Paulo)",
                Preco = 4590.00M,
                Image = @"/images/cruzeiros/offer_1.jpg"
            },
            new() {
                Id = 2,
                Nome = "Costa Fascinosa",
                Descricao = "América do Sul<br>9 Dias<br>Saindo de: Rio de Janeiro (Rio de Janeiro)<br>Porto de desembarque: Rio de Janeiro (Rio de Janeiro)",
                Preco = 4646.25M,
                Image = @"/images/cruzeiros/offer_2.jpg"
            },

             new() {
                Id = 3,
                Nome = "Norwegian Spirit",
                Descricao = "Pacífico Sul: Kauai & Moorea<br>12 Dias<br>Saindo de: Honolulu, Oahu<br>Porto de desembarque: Papeete, Taiti, Polinésia Francesa",
                Preco = 3463.00M,
                Image = @"/images/cruzeiros/offer_3.jpg"
            },

             new() {
                Id = 4,
                Nome = "Rhapsody of the Seas",
                Descricao = "Bahamas & Perfect Day Cruise<br>3 Noites<br>Saindo de: Fort Lauderdale, Flórida<br>Porto de desembarque: Fort Lauderdale, Flórida",
                Preco = 941.00M,
                Image = @"/images/cruzeiros/offer_4.jpg"
            }
        };
        builder.Entity<Cruzeiro>().HasData(cruzeiros);
        #endregion

        #region Ingressos
        List<Ingresso> ingressos = new() {
            new() {
                Id = 1,
                Nome = "Walt Disney World",
                Descricao = "INGRESSOS PARA OS PARQUES TEMÁTICOS WALT DISNEY WORLD<br>1 Dia (10 anos ou mais)",
                Preco = 548.76M,
                Image = @"/images/ingressos/castelo.jpg"
            },

            new() {
                Id = 2,
                Nome = "Beto Carrero World",
                Descricao = "PASSAPORTE DE ACESSO 1º LOTE<br>1 Dia (A partir de 05 anos)",
                Preco = 139.90M,
                Image = @"/images/ingressos/beto.jpg"
            },

            new() {
                Id = 3,
                Nome = "Thermas dos Laranjais",
                Descricao = "INGRESSO DIÁRIO INTEIRA OUTUBRO E NOVEMBRO 2023<br>1 Dia",
                Preco = 150.00M,
                Image = @"/images/ingressos/thermas.jpg"
            },

            new() {
                Id = 4,
                Nome = "Hopi Hari",
                Descricao = "HORA DO HORROR<br>1 Dia",
                Preco = 159.90M,
                Image = @"/images/ingressos/hopihari.jpg"
            }

        };
        builder.Entity<Ingresso>().HasData(ingressos);
        #endregion

         #region Pontos Turísticos
        List<PontoTuristico> PontosTuristicos = new() {
            new() {
                Id = 1,
                Nome = "Cristo Redentor",
                Descricao = "Rio de Janeiro<br>De braços abertos sobre a Guanabara, o Cristo Redentor recebe os visitantes e abençoa os cariocas.",
                Icone = @"/images/backpack.png",
                Image = @"/images/pontos/cristo.jpg"
            },
            new() {
                Id = 2,
                Nome = "Torre Eiffel",
                Descricao = "Paris<br>Esta joia da paisagem parisiense e símbolo máximo da França fica ainda mais espetacular quando vista de perto.",
                Icone = @"/images/backpack.png",
                Image = @"/images/pontos/torre.jpg"
            },
            new() {
                Id = 3,
                Nome = "Punta Cana",
                Descricao = "República Dominicana<br>A tropical Punta Cana se orgulha de ser um dos melhores destinos do Caribe, e sua fama é, de fato, justificada.",
                Icone = @"/images/island_t.png",
                Image = @"/images/pontos/praia.jpeg"
            },
            new() {
                Id = 4,
                Nome = "Gramado",
                Descricao = "Rio Grande do Sul<br>Romântica, charmosa, cheia de cultura, belas paisagens, atrações e ótima culinária.",
                Icone = @"/images/backpack.png",
                Image = @"/images/pontos/sul.jpeg"
            },

        };
        builder.Entity<PontoTuristico>().HasData(PontosTuristicos);
        #endregion

          #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
               Id = Guid.NewGuid().ToString(),
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole()
            {
               Id = Guid.NewGuid().ToString(),
               Name = "Funcionário",
               NormalizedName = "FUNCIONARIO"
            },
            new IdentityRole()
            {
               Id = Guid.NewGuid().ToString(),
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate IdentityUser
        List<IdentityUser> users = new(){
            new IdentityUser(){
                Id = Guid.NewGuid().ToString(),
                Email = "admin@viagens.com",
                NormalizedEmail = "ADMIN@VIAGENS.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                LockoutEnabled = false,
                EmailConfirmed = true,
            }
        };
        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "@Etec123");
        }
        builder.Entity<IdentityUser>().HasData(users);

        List<Usuario> usuarios = new(){
            new Usuario(){
                UsuarioId = users[0].Id,
                Nome = "Marina Porfirio",
                Foto = "/images/avatar.png"
            }
        };
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>() {
                UserId = users[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>() {
                UserId = users[0].Id,
                RoleId = roles[1].Id
            },
            new IdentityUserRole<string>() {
                UserId = users[0].Id,
                RoleId = roles[2].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}
