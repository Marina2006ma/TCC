using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AmandaViagens.Models;

     [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public string UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public IdentityUser AcocountUser { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(60, ErrorMessage = "O Nome deve possuir no máximo 60 caracteres")]
        public string Nome {get; set; }

        [StringLength(300)]
        public string Foto {get; set; }
    }
