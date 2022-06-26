namespace AlugaCarros.BalcaoAtendimento.BFF.Dtos.Locations;
public class LocationResponse
{
    public string Code { get; set; }
    public string ReservationCode { get; set; }
    public string AgencyCode { get; set; }
    public string ClientDocument { get; set; }
    public string VehicleGroupCode { get; set; }
    public string VehiclePlate { get; set; }
    public DateTime Date { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal Value { get; set; }
    public decimal SecurityDepositValue { get; set; }
}
