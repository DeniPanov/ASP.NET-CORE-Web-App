namespace ApiaryDiary.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class LocationsController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
