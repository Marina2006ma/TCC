using AmandaViagens.ViewModels;

namespace AmandaViagens.Services;

public interface IUsuarioService
{
    Task<UsuarioVM> GetUsuarioLogado();
}