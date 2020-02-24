namespace ApiaryDiary.Data.Models
{
    using System;

    public class Inspection
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int HoneyCombsCount { get; set; }

        public double HoneyInKilos { get; set; }

        public double BeehiveWeight { get; set; }

        public double Temperature { get; set; }

        public Beehive Beehive { get; set; }

        public int BeehiveId { get; set; }
    }
}
