namespace ApiaryDiary.Controllers
{
    using ApiaryDiary.Controllers.Models.Apiaries;
    using ApiaryDiary.Services;
    using Microsoft.AspNetCore.Mvc;

    public class ApiariesController : Controller
    {
        private readonly IApiaryService apiaryService;
        private readonly ILocationInfoService locationInfoService;

        public ApiariesController(
            IApiaryService apiaryService,
            ILocationInfoService locationInfoService)
        {
            this.apiaryService = apiaryService;
            this.locationInfoService = locationInfoService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateApiaryPostModel model)
        {
            if (ModelState.IsValid == false)
            {
                return this.View(model);
            }

            locationInfoService.CreateAsync(model.Settlement);
            apiaryService.CreateAsync(model.Name, model.Capacity);

            return this.Redirect("/"); //RedirectToAction("ViewAll()")
        }
    }
}
