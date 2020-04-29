namespace ApiaryDiary.Controllers.Models.Apiaries
{
    using ApiaryDiary.Services.Models.Apiaries;

    using System.Collections.Generic;

    public class ApiaryListingViewModel
    {
        public IEnumerable<ApiaryListingServiceModel> Apiaries { get; set; }
    }
}
