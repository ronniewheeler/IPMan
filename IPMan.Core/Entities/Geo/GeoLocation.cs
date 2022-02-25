using System.Collections.Generic;

namespace IPMan.Core.Entities.Geo
{
    public class GeoLocation
    {
        public int Id { get; set; }
        public string? Capital { get; set; }
        public IEnumerable<GeoLanguage>? Languages { get; set; }
        public string? CallingCode { get; set; }

    }
}
