namespace ApiaryDiary.Controllers.Models.QueenBees
{
    using ApiaryDiary.Data.Models.Enums;

    public class AllBeehivesWithoutQueensServiceViewModel
    {
        public int Id { get; set; }

        public string ApiaryName { get; set; }

        public int BeehiveNumber { get; set; }

        public QueenBeeType QueenType { get; set; }
    }
}