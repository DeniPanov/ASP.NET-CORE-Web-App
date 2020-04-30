namespace ApiaryDiary.Controllers.Models.Inspections
{
    using ApiaryDiary.Services.Models.Inspections;

    using System.Collections.Generic;

    public class InspectionsListingViewModel
    {
        public IEnumerable<InspectedHivesListingServiceModel> InspectedBeehives { get; set; }

        public IEnumerable<UninspectedHivesListingServiceModel> UnInspectedBeehives { get; set; }
    }
}
