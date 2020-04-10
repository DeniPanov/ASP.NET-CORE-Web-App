namespace ApiaryDiary.Data.Models
{
    using ApiaryDiary.Data.Models.Enums;

    using static Common.DataConstants.Apiary;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Apiary
    {
        public Apiary()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Beehives = new HashSet<Beehive>();
            this.Locations = new HashSet<LocationInfo>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ApiaryNameMaxLenght)]
        public string Name { get; set; }

        public BeekeepingType BeekeepingType { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Capacity { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Beehive> Beehives { get; set; }
                
        public virtual ICollection<LocationInfo> Locations { get; set; }
                
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
