using System.ComponentModel;

namespace AlugaCarros.BalcaoAtendimento.BFF.Dtos.Vehicles;
public enum VehicleStatus
{
    [Description("Disponível")]
    Available = 1,
    [Description("Alugado")]
    Rented = 2,
    [Description("Em Manutenção")]
    InMaintenance = 3,
    [Description("Inativo")]
    Inactive = 4
}
