namespace ApiaryDiary.Controllers.Models.QueenBees
{
    using System.Collections.Generic;

    public class AllBeehivesWithQueensListingViewModel
    {
        public IEnumerable<AllBeehivesWithQueensServiceViewModel> BeehivesWithQueens { get; set; }

        public IEnumerable<AllBeehivesWithoutQueensServiceViewModel> BeehivesWithoutQueens { get; set; }
    }
}
