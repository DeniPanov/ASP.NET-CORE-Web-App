namespace ApiaryDiary.Data.Models
{
    using ApiaryDiary.Data.Models.Enums;

    public class QueenBee
    {
        public int Id { get; set; }

        public QueenBeeType Type { get; set; }

        public string MarkingColour { get; set; }

        public string Origin { get; set; }

        public string Temper { get; set; }

        public virtual Beehive Beehive { get; set; }

        public int BeehiveId { get; set; }
    }
}
