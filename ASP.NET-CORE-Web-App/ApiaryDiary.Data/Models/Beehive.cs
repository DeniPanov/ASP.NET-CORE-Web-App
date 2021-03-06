﻿namespace ApiaryDiary.Data.Models
{
    using ApiaryDiary.Data.Models.Enums;

    using static ApiaryDiary.Data.Common.DataConstants.Beehive;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Beehive
    {
        public Beehive()
        {
            this.CreatedOn = DateTime.UtcNow;

            Inspections = new HashSet<Inspection>();
            Statistics = new HashSet<Statistics>();
            QueenBees = new HashSet<QueenBee>();
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        [Required]
        [MaxLength(BeehiveNumberMaxLenght)]
        public int Number { get; set; }

        [Required]
        public SystemType SystemType { get; set; }

        [Required]
        public BeehiveType BeehiveType { get; set; }

        public bool IsHungry { get; set; }

        public bool IsAlive { get; set; }

        public bool HasQueen { get; set; }

        public bool IsInspected { get; set; }

        public string Notes { get; set; }

        public virtual Apiary Apiary { get; set; }

        public int ApiaryId { get; set; }

        public virtual ICollection<Inspection> Inspections { get; set; }
                
        public virtual ICollection<Statistics> Statistics { get; set; }
                
        public virtual ICollection<QueenBee> QueenBees { get; set; }
    }
}
