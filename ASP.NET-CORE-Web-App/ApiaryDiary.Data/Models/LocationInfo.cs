namespace ApiaryDiary.Data.Models
{
    using static Common.DataConstants.LocationInfo;

    using System.ComponentModel.DataAnnotations;

    public class LocationInfo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(SettlementMaxLenght)]
        public string Settlement { get; set; }

        public int Altitude { get; set; }

        public bool HasHoneyPlants { get; set; }

        public virtual Apiary Apiary { get; set; }

        public int ApiaryId { get; set; }
    }
}
