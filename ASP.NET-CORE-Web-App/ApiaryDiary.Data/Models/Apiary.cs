namespace ApiaryDiary.Data.Models
{
    using System.Collections.Generic;

    using ApiaryDiary.Data.Models.Enums;

    public class Apiary
    {
        public Apiary()
        {
            this.Beehives = new HashSet<Beehive>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public BeekeepingType BeekeepingType { get; set; }

        //TODO: Add another type: static or mobile

        public LocationInfo LocationInfo { get; set; }

        public int Capacity { get; set; }

        public ICollection<Beehive> Beehives { get; set; }
    }
}
