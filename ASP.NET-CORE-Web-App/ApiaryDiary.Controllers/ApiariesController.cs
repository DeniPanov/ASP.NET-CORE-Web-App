namespace ApiaryDiary.Controllers
{
    using ApiaryDiary.Controllers.Models.Apiaries;
    using ApiaryDiary.Services;
    using ApiaryDiary.Services.Models.Apiaries;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    [Authorize]
    public class ApiariesController : Controller
    {
        private readonly IApiaryService apiaryService;
        private readonly IBeehiveService beehiveService;
        private readonly ILocationInfoService locationInfoService;
        private readonly UserManager<IdentityUser> userManager;

        public ApiariesController(
            IApiaryService apiaryService,
            IBeehiveService beehiveService,
            ILocationInfoService locationInfoService,
            UserManager<IdentityUser> userManager)
        {
            this.apiaryService = apiaryService;
            this.beehiveService = beehiveService;
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
                CreatePartialAsync(apiaryId, model.Settlement);

            await this.apiaryService.AddNewLocationAsync(locationId, apiaryId);

            return this.RedirectToAction(nameof(this.ViewAll));
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            await this.apiaryService.DeleteAsync(id);
            await this.beehiveService.DeleteAllBeehivesInApiary(id);

            return this.RedirectToAction(nameof(this.ViewAll));
        }

        public async Task<IActionResult> Details(int id)
        {
            var apiary = await this.apiaryService.DetailsAsync(id);

            if (apiary == null)
            {
                return this.NotFound();
            }

            return this.View(apiary);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var apiaryDetails = await this.apiaryService.DetailsAsync(id);

            if (apiaryDetails == null)
            {
                return this.NotFound();
            }

            EditApiaryPostModel editApiry = MapNewEditApiary(apiaryDetails);

            return this.View(editApiry);
        }        

        [HttpPost]
        public async Task<IActionResult> EditAsync(EditApiaryPostModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            await this.apiaryService.EditAsync(
                input.Id, input.Name, input.BeekeepingType, input.Capacity);

            return RedirectToAction(nameof(ViewAll));
        }

        public async Task<IActionResult> ViewAll()
        {
            var viewModel = new ApiaryListingViewModel();
            var apiaries = this.apiaryService.ViewAllAsync();

            viewModel.Apiaries = await apiaries;

            return this.View(viewModel);
        }

        private static EditApiaryPostModel MapNewEditApiary(ApiaryDetailsServiceModel apiary)
        {
            // TODO: Move this in the service
            return new EditApiaryPostModel
            {
                Id = apiary.Id,
                Name = apiary.Name,
                BeekeepingType = apiary.BeekeepingType,
                Capacity = apiary.Capacity
            };
        }
    }
}
