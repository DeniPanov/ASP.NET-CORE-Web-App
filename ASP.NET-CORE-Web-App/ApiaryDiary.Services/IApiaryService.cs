namespace ApiaryDiary.Services
{
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;
    using ApiaryDiary.Services.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IApiaryService
    {
        Task<int> CreateAsync(string userId, string name, int capacity);

        Task<IEnumerable<ApiaryListingServiceModel>> ViewAllAsync();

        Apiary FindById(int apiaryId);

        Task AddNewLocationAsync(int locationId, int apiaryId);

        int ApiariesCount();

        Task<ApiaryDetailsServiceModel> DetailsAsync(string id);

        Task EditAsync(int apiaryId, string name, BeekeepingType BeekeepingType, int capacity);

        Task DeleteAsync(int apiaryId);
    }
}
