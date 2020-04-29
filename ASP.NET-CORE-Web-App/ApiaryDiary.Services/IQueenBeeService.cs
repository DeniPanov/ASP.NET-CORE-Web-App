namespace ApiaryDiary.Services
{
    using ApiaryDiary.Controllers.Models.QueenBees;
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQueenBeeService
    {
        Task<int> Create(int beehiveId, QueenBeeType queenType,
            string markingColour, string origin, string temper);

        QueenBee FindById(int id);

        Task<IEnumerable<AllBeehivesWithQueensServiceViewModel>> GetAllBeehivesWithQueens();

        Task<IEnumerable<AllBeehivesWithoutQueensServiceViewModel>> GetAllBeehivesWithoutQueens();
    }
}
