namespace ApiaryDiary.Services.Models.Inspections
{
    using ApiaryDiary.Data.Models.Enums;

    public class UninspectedHivesListingServiceModel
    {
        public int Id { get; set; }

        public int BeehiveNumber { get; set; }

        public HiveCondition HiveCondition { get; set; }

        public int BeehiveId { get; set; }
    }
}
