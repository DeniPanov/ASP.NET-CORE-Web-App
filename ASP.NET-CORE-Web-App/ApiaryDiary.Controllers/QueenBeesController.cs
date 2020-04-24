namespace ApiaryDiary.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class QueenBeesController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
