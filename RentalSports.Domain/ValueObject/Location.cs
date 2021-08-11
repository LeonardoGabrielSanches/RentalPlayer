namespace RentalSports.Domain.ValueObject
{
    public class Location
    {
        public Location(
            decimal latitude,
            decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
    }
}
