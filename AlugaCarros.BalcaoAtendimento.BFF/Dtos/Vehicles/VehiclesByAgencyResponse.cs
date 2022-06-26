namespace AlugaCarros.BalcaoAtendimento.BFF.Dtos.Vehicles;

public class VehiclesByAgencyResponse : List<VehicleByAgency>
{
}

public class VehicleByAgency
{
    public string Plate { get; set; }
    public string Model { get; set; }
    public string VehicleGroup { get; set; }
    public string VehicleGroupDescription { get; set; }
    public VehicleStatus Status { get; set; }
}
