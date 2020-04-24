namespace ApiaryDiary.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class NotebookController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
