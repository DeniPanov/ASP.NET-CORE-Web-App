namespace ApiaryDiary.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ApiaryDiary.Data.Models.Enums;

    public class Apiary
    {
        public Apiary()
        {
            this.Beehives = new HashSet<Beehive>();
            this.Locations = new HashSet<LocationInfo>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)] //TODO: Use constants.
        public string Name { get; set; }

        public BeekeepingType BeekeepingType { get; set; }

        public LocationInfo LocationInfo { get; set; }

        [Required]
        public int Capacity { get; set; }

        public DateTime CreatedOn => DateTime.UtcNow;

        public ICollection<Beehive> Beehives { get; set; }

        public ICollection<LocationInfo> Locations { get; set; }
    }
}
