using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AmandaViagens.Models;

    [Table("Aeroporto")]
    public class Aeroporto
    
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }
        public string Cidade { get; set; }
        [ForeignKey("Cidade")]
        public Cidade CidadeId { get; set; }
    }