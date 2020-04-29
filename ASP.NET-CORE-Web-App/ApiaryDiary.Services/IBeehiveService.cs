namespace ApiaryDiary.Services
{
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;
    using ApiaryDiary.Services.Models.Beehives;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBeehiveService
    {
        Task<int> CreateAsync(
            int apiaryId, int number, SystemType systemType, BeehiveType beehiveType);

        void CreateMultiple(
            int apiaryId, int firstNumber,int lastNumber,
            SystemType systemType,BeehiveType beehiveType);

        void Delete(int id);

        Task DeleteAllBeehivesInApiary(int apiaryId);

        Task<BeehiveDetailsServiceModel> DetailsAsync(int beehiveId);

        Task EditAsync
            (int beehiveId, int number, SystemType systemType, BeehiveType beehiveType);

        Beehive FindById(int beehiveId);

        Task<IEnumerable<BeehiveListingServiceModel>> ViewAllAsync();
    }
}
