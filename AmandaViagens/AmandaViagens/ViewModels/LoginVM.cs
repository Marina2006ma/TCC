using System.ComponentModel.DataAnnotations;

namespace AmandaViagens.ViewModels;

public class LoginVM
{
    [Display(Name = "Email", Prompt = "Informe seu Email")]
    [Required(ErrorMessage = "Por favor, informe seu email")]
    public string Email { get; set; }

    [Display(Name = "Senha de Acesso", Prompt = "Informe sua Senha")]
    [Required(ErrorMessage = "Por favor, informe sua senha")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [Display(Name = "Manter Conectado?")]
    public bool Lembrar { get; set; } = false;

    public string UrlRetorno { get; set; }
}
