namespace ApiaryDiary.Data.Models
{
    using System.Collections.Generic;

    using ApiaryDiary.Data.Models.Enums;

    public class Beehive
    {
        public Beehive()
        {
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }

        public int Number { get; set; }

        public SystemType SystemType { get; set; }

        public bool IsHungry { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}
