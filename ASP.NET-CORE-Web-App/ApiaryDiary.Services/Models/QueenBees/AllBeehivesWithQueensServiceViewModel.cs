namespace ApiaryDiary.Controllers.Models.QueenBees
{
    using ApiaryDiary.Data.Models.Enums;

    using System;

    public class AllBeehivesWithQueensServiceViewModel
    {
        public int Id { get; set; }

        public string ApiaryName { get; set; }

        public int BeehiveNumber { get; set; }

        public QueenBeeType QueenType { get; set; }

        public DateTime QueenCreatedOn { get; set; }
    }
}