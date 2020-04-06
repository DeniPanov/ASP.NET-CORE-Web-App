namespace ApiaryDiary.Services.Models
{
    using ApiaryDiary.Data.Models.Enums;

    using System.ComponentModel.DataAnnotations;

    public class ApiaryDetailsServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BeekeepingType BeekeepingType { get; set; }

        public int Capacity { get; set; }

        [DataType(DataType.Date)]
        public string CreatedOn { get; set; }

        public int BeehivesCount { get; set; }
    }
}
