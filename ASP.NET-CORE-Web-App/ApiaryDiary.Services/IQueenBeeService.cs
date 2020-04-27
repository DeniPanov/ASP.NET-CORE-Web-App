namespace ApiaryDiary.Services
{
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;
    using System.Threading.Tasks;

    public interface IQueenBeeService
    {
        Task<int> Create(int beehiveId, QueenBeeType queenType,
            string markingColour, string origin, string temper);

        QueenBee FindById(int id);
    }
}
