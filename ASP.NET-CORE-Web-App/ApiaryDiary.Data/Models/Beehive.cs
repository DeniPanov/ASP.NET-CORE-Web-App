namespace ApiaryDiary.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ApiaryDiary.Data.Models.Enums;

    public class Beehive
    {
        public Beehive()
        {
            Inspections = new HashSet<Inspection>();
            Statistics = new HashSet<Statistics>();
            QueenBees = new HashSet<QueenBee>();
        }

        public int Id { get; set; }
        
        [Required]
        public SystemType SystemType { get; set; }

        public bool IsHungry { get; set; }

        public bool IsAlive { get; set; }

        public string Notes { get; set; }

        public Apiary Apiary { get; set; }

        public int ApiaryId { get; set; }

        public ICollection<Inspection> Inspections { get; set; }

        public ICollection<Statistics> Statistics { get; set; }

        public ICollection<QueenBee> QueenBees { get; set; }
    }
}
