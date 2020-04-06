namespace ApiaryDiary.Controllers.Models.Apiaries
{
    using ApiaryDiary.Data.Models.Enums;

    using System.ComponentModel.DataAnnotations;

    using static ApiaryDiary.Data.Common.DataConstants.Apiary;

    public class EditApiaryPostModel
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
    }
}
