namespace IPMan.Core.Entities.Geo
{
    public class GeoIP
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? IP { get; set; }
        public string? IPType { get; set; }
        public string? Continent { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }
        public GeoLocation? Location { get; set; }
}
}
