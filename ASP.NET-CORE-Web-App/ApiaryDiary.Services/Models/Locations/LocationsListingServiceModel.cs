namespace ApiaryDiary.Controllers.Models.Locations
{
    public class LocationsListingServiceModel
    {
        public int Id { get; set; }

        public string ApiaryName { get; set; }

        public string Settlement { get; set; }

        public int Altitude { get; set; }

        public string Description { get; set; }
    }
}