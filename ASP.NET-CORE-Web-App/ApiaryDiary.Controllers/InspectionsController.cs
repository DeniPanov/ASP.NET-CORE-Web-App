namespace ApiaryDiary.Controllers
{
    using ApiaryDiary.Controllers.Models.Inspections;
    using ApiaryDiary.Services;

    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    public class InspectionsController : Controller
    {
        private readonly IInspectionService inspectionService;
        private readonly IBeehiveService beehiveService;

        public InspectionsController(
            IInspectionService inspectionService,
            IBeehiveService beehiveService)
        {
            this.inspectionService = inspectionService;
            this.beehiveService = beehiveService;
        }

        public async Task<IActionResult> AllHivesWithInspections()
        {
            var viewModel = new InspectionsListingViewModel();
            var allInspections = await this.inspectionService.GetAllInspectedHives();

            viewModel.InspectedBeehives = allInspections;

            return this.View(viewModel);
        }

        public async Task<IActionResult> AllHivesWithoutInspections()
        {
            var viewModel = new InspectionsListingViewModel();
            var allInspections = await this.inspectionService.GetAllUninspectedHives();

            viewModel.UnInspectedBeehives = allInspections;

            return this.View(viewModel);
        }

        public IActionResult Create(int id)
        {
            var model = new AddInspectionPostModel()
            {
                BeehiveId = id,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddInspectionPostModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            await this.inspectionService.CreateAsync(
                input.Id, input.HiveCondition, input.HygieneLevel, input.HoneyCombsCount,
                input.HoneyInKilos, input.BeehiveWeight, input.Temperature);

            return this.RedirectToAction(nameof(AllHivesWithInspections));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.NotFound();
            }

            await this.inspectionService.DeleteAsync(id);

            return this.RedirectToAction(nameof(AllHivesWithInspections));
        }
    }
}
