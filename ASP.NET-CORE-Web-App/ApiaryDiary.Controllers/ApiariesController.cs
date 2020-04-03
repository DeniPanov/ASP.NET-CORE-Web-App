namespace ApiaryDiary.Controllers
{
    using ApiaryDiary.Controllers.Models.Apiaries;
    using ApiaryDiary.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ApiariesController : Controller
    {
        private readonly IApiaryService apiaryService;
        private readonly ILocationInfoService locationInfoService;
        private readonly UserManager<IdentityUser> userManager;

        public ApiariesController(
            IApiaryService apiaryService,
            ILocationInfoService locationInfoService,
            UserManager<IdentityUser> userManager)
        {
            this.apiaryService = apiaryService;
            this.locationInfoService = locationInfoService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateApiaryPostModel model)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(model);
            }

            var userId = this.userManager.GetUserId(this.User);

            var apiaryId = await this.apiaryService.
                CreateAsync(userId, model.Name, model.Capacity);
            var locationId = await this.locationInfoService.
                CreateAsync(apiaryId, model.Settlement);

            await this.apiaryService.AddNewLocationAsync(locationId, apiaryId);

            return this.Redirect("/"); //RedirectToAction("ViewAll()")
        }

        public IActionResult ViewAll()
        {
            var viewModel = new ApiaryListingViewModel();
            var apiaries = apiaryService.ViewAll();

            viewModel.Apiaries = apiaries;

            return this.View(viewModel);
        }
    }
}
