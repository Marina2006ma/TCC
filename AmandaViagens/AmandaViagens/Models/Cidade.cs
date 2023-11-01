using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AmandaViagens.Models;

    [Table("Cidade")]
    public class Cidade
    
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Estado")]
        [StringLength(80, ErrorMessage = "O Estado deve possuir no máximo 80 caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe o País")]
        [StringLength(80, ErrorMessage = "O País deve possuir no máximo 80 caracteres")]
        public string Pais { get; set; }
    }