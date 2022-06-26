namespace AlugaCarros.BalcaoAtendimento.BFF.Dtos.Users;

public class UserToken
{
    public string Id { get; set; }
    public string Email { get; set; }
    public IEnumerable<UserClaim> Claims { get; set; }
}
