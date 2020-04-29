namespace ApiaryDiary.Controllers.Models.Locations
{
    using System.Collections.Generic;

    public class LocationsListingViewModel
    {
        public IEnumerable<LocationsListingServiceModel> Locations { get; set; }
    }
}
