using System.ComponentModel.DataAnnotations;

namespace AlugaCarros.BalcaoAtendimento.BFF.Dtos.Users;

public class UserLogin
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
    [Display(Name = "Senha")]
    public string Password { get; set; }
}