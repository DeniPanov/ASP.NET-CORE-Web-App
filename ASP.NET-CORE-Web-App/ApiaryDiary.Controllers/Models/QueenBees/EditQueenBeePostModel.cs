namespace ApiaryDiary.Controllers.Models.QueenBees
{
    using ApiaryDiary.Data.Models.Enums;

    public class EditQueenBeePostModel
    {
        public int Id { get; set; }

        public QueenBeeType QueenType { get; set; }

        public string MarkingColour { get; set; }

        public string Origin { get; set; }

        public string Temper { get; set; }
    }
}
