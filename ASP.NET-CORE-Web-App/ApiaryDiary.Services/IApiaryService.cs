namespace ApiaryDiary.Services
{
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Services.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IApiaryService
    {
        Task<int> CreateAsync(string userId, string name, int capacity);

        IEnumerable<ApiaryListingServiceModel> ViewAll();

        Apiary FindById(int apiaryId);

        Task AddNewLocationAsync(int locationId, int apiaryId);
    }
}
