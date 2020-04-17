namespace ApiaryDiary.Services
{
    using ApiaryDiary.Data.Models.Enums;
    using ApiaryDiary.Services.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBeehiveService
    {
        Task<int> CreateAsync(
            int apiaryId, int number, SystemType systemType, BeehiveType beehiveType);

        void CreateMultiple(
            int apiaryId, int firstNumber,int lastNumber,
            SystemType systemType,BeehiveType beehiveType);

        Task<IEnumerable<BeehiveListingServiceModel>> ViewAllAsync();
    }
}
