using AmandaViagens.Models;
using Microsoft.EntityFrameworkCore;

namespace AmandaViagens.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        List<Cruzeiro> cruzeiros = new() {
            new() {
                Id = 1,
                Nome = "",
                Descricao = "América do Sul<br>",
                Preco = 10M,
                Image = @""
            },
            new() {
                Id = 2,
                Nome = "",
                Descricao = "",
                Preco = 10M,
                Image = @""
            },
        };
        builder.Entity<Cruzeiro>().HasData(cruzeiros);


    }
}
