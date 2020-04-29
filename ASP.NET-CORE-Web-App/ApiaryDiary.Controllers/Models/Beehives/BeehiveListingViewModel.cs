namespace ApiaryDiary.Controllers.Models.Beehives
{
    using ApiaryDiary.Services.Models.Beehives;

    using System.Collections.Generic;

    public class BeehiveListingViewModel
    {
        public IEnumerable<BeehiveListingServiceModel> Beehives { get; set; }
    }
}
