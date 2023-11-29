

using Doss.Core.Seedwork;

namespace Doss.Core.Queries.ZipCode;

public class ZipCodeQuery : Query<ZipCodeQuery.Response>
{
    public string Code { get; set; } = null!;

    public class Response
    {
        public City City { get; private set; }
        public State State { get; private set; }
        public double? Altitude { get; private set; }
        public double? Latitude { get; private set; }
        public double? Longitude { get; private set; }
        public string Neighborhood { get; private set; }
        public string Complement { get; private set; }
        public string Code { get; private set; }
        public string Street { get; private set; }

        public Response(State state, City city, string code, string neighborhood, string street, string complement, double? altitude, double? latitude, double? longitude)
            => (State, City, Code, Neighborhood, Street, Complement, Altitude, Latitude, Longitude) = (state, city, code, neighborhood, street, complement, altitude, latitude, longitude);
    }

    public class City
    {
        public string Ibge { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public int DDD { get; private set; }

        public City(string ibge, string name, int ddd)
            => (Ibge, Name, DDD) = (ibge, name, ddd);
    }

    public class State
    {
        public string Sigla { get; private set; }
        public State(string sigla)
            => Sigla = sigla;
    }
}