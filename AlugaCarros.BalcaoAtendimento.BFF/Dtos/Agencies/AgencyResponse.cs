﻿namespace AlugaCarros.BalcaoAtendimento.BFF.Dtos.Agencies;
public class AgencyResponse : List<Agency>
{

}

public class Agency
{
    public string AgencyCode { get; set; }
    public string AgencyName { get; set; }
}
