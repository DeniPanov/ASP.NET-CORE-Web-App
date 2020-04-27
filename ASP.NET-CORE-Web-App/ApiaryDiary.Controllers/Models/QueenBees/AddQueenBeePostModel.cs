namespace ApiaryDiary.Controllers.Models.QueenBees
{
    using ApiaryDiary.Data.Models.Enums;

    using static ApiaryDiary.Data.Common.DataConstants.QueenBee;

    using System.ComponentModel.DataAnnotations;

    public class AddQueenBeePostModel
    {
        public int Id { get; set; }

        public QueenBeeType QueenType { get; set; }

        [MaxLength(MarkingColourMaxLenght)]
        [MinLength(MarkingColourMinLenght)]
        public string MarkingColour { get; set; }

        [MaxLength(OriginMaxLenght)]
        [MinLength(OriginMinLenght)]
        public string Origin { get; set; }

        [MaxLength(TemperMaxLenght)]
        [MinLength(TemperMinLenght)]
        public string Temper { get; set; }
    }
}
