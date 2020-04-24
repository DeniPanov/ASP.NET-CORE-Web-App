namespace ApiaryDiary.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class StatisticsController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
