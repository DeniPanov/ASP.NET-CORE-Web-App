namespace ApiaryDiary.Controllers
{
    using ApiaryDiary.Controllers.Models.QueenBees;
    using ApiaryDiary.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    [Authorize]
    public class QueenBeesController : Controller
    {
        private readonly IQueenBeeService queenBeeService;
        private readonly IBeehiveService beehiveService;

        public QueenBeesController(
            IQueenBeeService queenBeeService,
            IBeehiveService beehiveService)
        {
            this.queenBeeService = queenBeeService;
            this.beehiveService = beehiveService;
        }

        public async Task<IActionResult> AllHivesWithQueens()
        {
            var viewModel = new AllBeehivesWithQueensListingViewModel();
            var allBeehivesWithQueens = await this.queenBeeService.GetAllBeehivesWithQueens();

            viewModel.BeehivesWithQueens = allBeehivesWithQueens;

            return this.View(viewModel);
        }

        public async Task<IActionResult> AllHivesWithoutQueens()
        {
            var viewModel = new AllBeehivesWithQueensListingViewModel();
            var allBeehivesWithQueens = await this.queenBeeService.GetAllBeehivesWithoutQueens();

            viewModel.BeehivesWithoutQueens = allBeehivesWithQueens;

            return this.View(viewModel);
        }

        public IActionResult Create(int id)
        {
            var model = new AddQueenBeePostModel()
            {
                BeehiveId = id,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(AddQueenBeePostModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            var beehive = this.beehiveService.FindById(input.BeehiveId);

            this.queenBeeService.Create(
                input.BeehiveId, input.QueenType, input.MarkingColour, input.Origin, input.Temper);
            
            return this.RedirectToAction("ViewAll", "Beehives");
        }

        public IActionResult Delete(int id)
        {
            return this.View();
        }

        public IActionResult Edit(int id)
        {
            return this.View();
        }

    }
}
