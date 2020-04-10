namespace ApiaryDiary.Data.Models
{
    using static Common.DataConstants.LocationInfo;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class LocationInfo
    {
        public LocationInfo()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [MaxLength(SettlementMaxLenght)]
        public string Settlement { get; set; }

        public int Altitude { get; set; }

        public bool HasHoneyPlants { get; set; }

        public virtual Apiary Apiary { get; set; }

        public int ApiaryId { get; set; }
    }
}
