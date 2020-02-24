namespace ApiaryDiary.Data.Models
{
    using System.Collections.Generic;

    using ApiaryDiary.Data.Models.Enums;

    public class Beehive
    {
        public Beehive()
        {
            Inspections = new HashSet<Inspection>();
        }

        public int Id { get; set; }

        public int Number { get; set; }

        public SystemType SystemType { get; set; }

        public bool IsHungry { get; set; }

        public string Notes { get; set; }

        public Apiary Apiary { get; set; }

        public int ApiaryId { get; set; }

        public ICollection<Inspection> Inspections { get; set; }
    }
}
