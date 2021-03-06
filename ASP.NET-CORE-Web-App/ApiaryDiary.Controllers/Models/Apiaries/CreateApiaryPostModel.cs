﻿namespace ApiaryDiary.Controllers.Models.Apiaries
{
    using ApiaryDiary.Data.Models.Enums;

    using static ApiaryDiary.Data.Common.DataConstants.Apiary;
    using static ApiaryDiary.Data.Common.DataConstants.LocationInfo;

    using System.ComponentModel.DataAnnotations;

    public class CreateApiaryPostModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ApiaryNameMinLenght)]
        [MaxLength(ApiaryNameMaxLenght)]
        [Display(Name = "Apiary Name")]
        public string Name { get; set; }

        [Display(Name = "Beekeeping Type")]
        public BeekeepingType BeekeepingType { get; set; }

        [Required]
        [Range(ApiaryCapacityMinLenght, ApiaryCapacityMaxLenght)]
        public int Capacity { get; set; }

        [Required]
        [MaxLength(SettlementMaxLenght)]
        public string Settlement { get; set; }
    }
}
