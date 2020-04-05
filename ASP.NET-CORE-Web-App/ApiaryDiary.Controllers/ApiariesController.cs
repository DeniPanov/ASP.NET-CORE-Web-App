namespace ApiaryDiary.Controllers
{
    using ApiaryDiary.Controllers.Models.Apiaries;
    using ApiaryDiary.Services;
    using ApiaryDiary.Services.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Authorize]
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

            return this.RedirectToAction("ViewAll");
        }

        public async Task<IActionResult> ViewAll()
        {
            var viewModel = new ApiaryListingViewModel();
            var apiaries = this.apiaryService.ViewAllAsync();

            viewModel.Apiaries = await apiaries;

            return this.View(viewModel);
        }

        public IActionResult Edit()
        {
            return this.View();
        }


        public async Task<IActionResult> Details()
        {
            var userId = this.userManager.GetUserId(this.User);
            var apiary = await this.apiaryService.DetailsAsync(userId);

            if (apiary == null)
            {
                return this.NotFound();
            }

            return this.View(apiary);
        }

        public IActionResult Delete()
        {
            return this.View();
        }
    }
}
