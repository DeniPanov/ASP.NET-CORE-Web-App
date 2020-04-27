namespace ApiaryDiary.Data.Models
{
    using ApiaryDiary.Data.Models.Enums;

    using static Common.DataConstants.QueenBee;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class QueenBee
    {
        public QueenBee()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        public QueenBeeType Type { get; set; }

        [MaxLength(MarkingColourMaxLenght)]
        public string MarkingColour { get; set; }

        [MaxLength(OriginMaxLenght)]
        public string Origin { get; set; }

        [MaxLength(TemperMaxLenght)]
        public string Temper { get; set; }

        public virtual Beehive Beehive { get; set; }

        public int BeehiveId { get; set; }
    }
}
