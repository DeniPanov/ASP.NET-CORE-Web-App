namespace ApiaryDiary.Controllers
{
    using ApiaryDiary.Controllers.Models.Beehives;
    using ApiaryDiary.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    [Authorize]
    public class BeehivesController : Controller
    {
        private readonly IBeehiveService beehiveService;
        private readonly IApiaryService apiaryService;
        private readonly UserManager<IdentityUser> userManager;

        public BeehivesController(
            IBeehiveService beehiveService,
            IApiaryService apiaryService,
            UserManager<IdentityUser> userManager)
        {
            this.beehiveService = beehiveService;
            this.apiaryService = apiaryService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            var userId = this.userManager.GetUserId(this.User);

            var model = new AddBeehivePostModel()
            {
                AllApairies = this.apiaryService.GetAll(userId),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddBeehivePostModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            var apiaryId = input.SelectedApiary;

            if (ModelState.IsValid == false)
            {
                input.AllApairies = this.apiaryService.GetAll(userId);
                return this.View(input);
            }

            await this.beehiveService.CreateAsync(
                apiaryId, input.Number, input.SystemType, input.BeehiveType);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult CreateMultiple()
        {
            var userId = this.userManager.GetUserId(this.User);

            var model = new AddBeehivesInRangePostModel()
            {
                AllApairies = this.apiaryService.GetAll(userId),
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult CreateMultiple(AddBeehivesInRangePostModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            var apiaryId = input.SelectedApiary;

            if (ModelState.IsValid == false)
            {
                input.AllApairies = this.apiaryService.GetAll(userId);
                return this.View(input);
            }

            this.beehiveService.CreateMultiple(
               apiaryId, input.FirstNumber, input.LastNumber,
               input.SystemType, input.BeehiveType);

            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            this.beehiveService.Delete(id);

            return this.RedirectToAction(nameof(ViewAll));
        }

        public async Task<IActionResult> Details(int id)
        {
            var beehive = await this.beehiveService.DetailsAsync(id);

            if (beehive == null)
            {
                return this.NotFound();
            }

            return this.View(beehive);
        }

        public IActionResult Edit(int id)
        {
            var beehive = this.beehiveService.FindById(id);

            var editBeehive = new EditBeehivePostModel
            {
                Id = id,
                Number = beehive.Number,
                SystemType = beehive.SystemType,
                BeehiveType = beehive.BeehiveType
            };

            return this.View(editBeehive);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBeehivePostModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            // var beehive = this.beehiveService.FindById(id);
            await this.beehiveService.EditAsync
                (input.Id, input.Number, input.SystemType, input.BeehiveType);

            return this.RedirectToAction(nameof(ViewAll));
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> ViewAll()
        {
            var viewModel = new BeehiveListingViewModel();
            var beehives = await this.beehiveService.ViewAllAsync();

            viewModel.Beehives = beehives;

            return this.View(viewModel);
        }
    }
}
