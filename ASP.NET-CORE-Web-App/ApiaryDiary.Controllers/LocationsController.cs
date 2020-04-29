namespace ApiaryDiary.Controllers
{
    using ApiaryDiary.Controllers.Models.Locations;
    using ApiaryDiary.Services;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    public class LocationsController : Controller
    {
        private readonly ILocationInfoService locationInfoService;
        private readonly IApiaryService apiaryService;
        private readonly UserManager<IdentityUser> userManager;

        public LocationsController(
            ILocationInfoService locationInfoService,
            IApiaryService apiaryService,
            UserManager<IdentityUser> userManager)
        {
            this.locationInfoService = locationInfoService;
            this.apiaryService = apiaryService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            var userId = this.userManager.GetUserId(this.User);

            var model = new AddLocationPostModel()
            {
                AllApairies = this.apiaryService.GetAll(userId),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddLocationPostModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            var apiaryId = input.SelectedApiary;

            if (ModelState.IsValid == false)
            {
                input.AllApairies = this.apiaryService.GetAll(userId);
                return this.View(input);
            }

            await this.locationInfoService.CreateDetailedAsync(
                apiaryId, input.Settlement, input.Altitude, input.HasHoneyPlants, input.Description);

            return this.RedirectToAction(nameof(ViewAll));
        }

        public IActionResult Edit(int id)
        {
            var location = this.locationInfoService.FindById(id);

            if (location == null)
            {
                return this.NotFound();
            }

            var viewModel = new EditLocationPostModel
            {
                Id = location.Id,
                Settlement = location.Settlement,
                Altitude = location.Altitude,
                Description = location.Description,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditLocationPostModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            await this.locationInfoService.EditAsync
                (input.Id, input.Settlement, input.Altitude, input.Description);

            return this.RedirectToAction(nameof(ViewAll));
        }

        public async Task<IActionResult> ViewAll()
        {
            var viewModel = new LocationsListingViewModel();
            var allLocations = await this.locationInfoService.ViewAll();

            viewModel.Locations = allLocations;

            return this.View(viewModel);
        }
    }
}
