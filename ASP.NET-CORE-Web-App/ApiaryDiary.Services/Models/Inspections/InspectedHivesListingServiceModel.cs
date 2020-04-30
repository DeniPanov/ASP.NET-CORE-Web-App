namespace ApiaryDiary.Services.Models.Inspections
{
    using ApiaryDiary.Data.Models.Enums;

    public class InspectedHivesListingServiceModel
    {
        public int Id { get; set; }

        public int BeehiveNumber { get; set; }

        public HiveCondition HiveCondition { get; set; }

        public string HygieneLevel { get; set; }

        public int HoneyCombsCount { get; set; }

        public double HoneyInKilos { get; set; }

        public int BeehiveId { get; set; }
    }
}