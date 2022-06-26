using AlugaCarros.BalcaoAtendimento.BFF.Extensions;

namespace AlugaCarros.BalcaoAtendimento.BFF.Dtos.Vehicles;

public class VehicleByAgencyResult
{
    public VehicleByAgencyResult(VehicleByAgency vehicleByAgency)
    {
        Plate = vehicleByAgency.Plate;
        Model = vehicleByAgency.Model;
        VehicleGroup = $"{vehicleByAgency.VehicleGroup} - {vehicleByAgency.VehicleGroupDescription}";
        VehicleStatus = EnumHelper.GetEnumDescription(vehicleByAgency.Status);
        Status = vehicleByAgency.Status;
    }

    public string Plate { get; set; }
    public string Model { get; set; }
    public string VehicleGroup { get; set; }
    public string VehicleStatus { get; set; }
    public VehicleStatus Status { get; set; }
}