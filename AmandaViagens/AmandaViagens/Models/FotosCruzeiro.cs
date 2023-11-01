using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AmandaViagens.Models;

    [Table("FotosCruzeiro")]
    public class FotosCruzeiro
    
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no máximo 80 caracteres")]
        public string Nome {get; set; }

        [Display(Name = "Descrição")]
        [StringLength(2000, ErrorMessage = "A Descrição  deve possuir no máximo 2000 caracteres")]
        public string Descricao {get; set; }
        
        [StringLength(200)]
        [Display(Name = "Foto")]
        public string Image { get; set; }
    }
