namespace ApiaryDiary.Controllers
{
    using ApiaryDiary.Controllers.Models.Beehives;
    using ApiaryDiary.Services;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

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

        public IActionResult Index()
        {
            return this.View();
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

        public IActionResult ViewAll()
        {
            return this.View();
        }
    }
}
