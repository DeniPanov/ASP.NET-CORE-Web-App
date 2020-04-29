namespace ApiaryDiary.Controllers.Models.Locations
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Collections.Generic;

    public class AddLocationPostModel
    {
        public int Id { get; set; }

        public string Settlement { get; set; }

        public int Altitude { get; set; }

        public bool HasHoneyPlants { get; set; }

        public string Description { get; set; }

        public int SelectedApiary { get; set; }

        public IEnumerable<SelectListItem> AllApairies { get; set; }
    }
}
