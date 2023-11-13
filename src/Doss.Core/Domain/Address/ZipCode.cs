namespace Doss.Core.Domain.Addresses;

public class ZipCode
{
    public bool IsSuccess 
        => Cep.IsNotNullOrEmpty();
    public Cidade Cidade { get; set; } = new Cidade();
    public Estado Estado { get; set; } = new Estado();
    public double? Altitude { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string Bairro { get; set; } = string.Empty;
    public string Complemento { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    public string Logradouro { get; set; } = string.Empty;

    public bool? IsValid
        => Latitude.HasValue && Latitude.Value > 0 && Longitude.HasValue && Longitude.Value > 0;
}

public class Cidade
{
    public string Ibge { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public int DDD { get; set; }
}

public class Estado
{
    public string Sigla { get; set; } = string.Empty;
}