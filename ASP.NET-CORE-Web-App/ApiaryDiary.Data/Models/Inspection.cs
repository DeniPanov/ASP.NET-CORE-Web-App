namespace ApiaryDiary.Data.Models
{
    using System;

    public class Inspection
    {
        public Inspection()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int HoneyCombsCount { get; set; }

        public double HoneyInKilos { get; set; }

        public double BeehiveWeight { get; set; }

        public double Temperature { get; set; }

        public virtual Beehive Beehive { get; set; }

        public int BeehiveId { get; set; }
    }
}
