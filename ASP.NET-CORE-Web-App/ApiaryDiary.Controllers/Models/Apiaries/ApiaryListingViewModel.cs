namespace ApiaryDiary.Controllers.Models.Apiaries
{
    using ApiaryDiary.Services.Models;

    using System.Collections.Generic;

    public class ApiaryListingViewModel
    {
        public IEnumerable<ApiaryListingServiceModel> Apiaries { get; set; }
    }
}
