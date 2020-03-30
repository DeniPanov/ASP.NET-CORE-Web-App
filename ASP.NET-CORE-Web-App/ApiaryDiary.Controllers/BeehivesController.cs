namespace ApiaryDiary.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BeehivesController : Controller
    {
        public BeehivesController()
        {

        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
