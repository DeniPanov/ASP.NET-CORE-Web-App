namespace ApiaryDiary.Controllers
{
    using ApiaryDiary.Controllers.Models.QueenBees;
    using ApiaryDiary.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Create()
        {
            var model = new AddQueenBeePostModel()
            {
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(int id, AddQueenBeePostModel input)
        {
            if (this.ModelState.IsValid == false)
            {
                return this.View(input);
            }

            var beehive = this.beehiveService.FindById(id);

            this.queenBeeService.Create(
                id, input.QueenType, input.MarkingColour, input.Origin, input.Temper);
            
            return this.RedirectToAction("AllHivesWithQueens", "QueenBees");
        }

        public IActionResult AllHivesWithQueens()
        {
            return this.View();
        }

        public IActionResult AllHivesWithoutQueens()
        {
            return this.View();
        }
    }
}
