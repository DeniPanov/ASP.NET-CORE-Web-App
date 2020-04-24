namespace ApiaryDiary.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class InspectionsController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
