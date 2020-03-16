namespace ApiaryDiary.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ApiaryDiary.Data.Models.Enums;

    using static Common.DataConstants.QueenBee;

    public class QueenBee
    {
        public QueenBee()
        {
            Type = QueenBeeType.Swarm;
        }

        public int Id { get; set; }

        [Required]
        public QueenBeeType Type { get; set; }

        [MaxLength(MarkingColourLenght)]
        public string MarkingColour { get; set; }

        [MaxLength(OriginLenght)]
        public string Origin { get; set; }

        [MaxLength(TemperLenght)]
        public string Temper { get; set; }

        public virtual Beehive Beehive { get; set; }

        public int BeehiveId { get; set; }
    }
}
