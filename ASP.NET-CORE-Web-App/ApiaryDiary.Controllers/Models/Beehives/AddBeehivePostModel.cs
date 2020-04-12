namespace ApiaryDiary.Controllers.Models.Beehives
{
    using ApiaryDiary.Data.Models.Enums;

    using static ApiaryDiary.Data.Common.DataConstants.Beehive;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddBeehivePostModel
    {
        public int Id { get; set; }

        [Range(BeehiveNumberMinLenght, BeehiveNumberMaxLenght)]
        public int Number { get; set; }

        [Display(Name = "System Type")]
        public SystemType SystemType { get; set; }

        [Display(Name = "Beehive Type")]
        public BeehiveType BeehiveType { get; set; }

        [Display(Name = "Select Apiary")]
        public int SelectedApiary { get; set; }

        public IEnumerable<SelectListItem> AllApairies { get; set; }
    }
}
