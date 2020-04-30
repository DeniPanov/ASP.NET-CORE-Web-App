namespace ApiaryDiary.Controllers.Models.Inspections
{
    using ApiaryDiary.Data.Models.Enums;

    using System;

    public class AddInspectionPostModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public HiveCondition HiveCondition { get; set; }

        public string HygieneLevel { get; set; }

        public int HoneyCombsCount { get; set; }

        public double HoneyInKilos { get; set; }

        public double BeehiveWeight { get; set; }

        public double Temperature { get; set; }

        public int BeehiveId { get; set; }
    }
}
