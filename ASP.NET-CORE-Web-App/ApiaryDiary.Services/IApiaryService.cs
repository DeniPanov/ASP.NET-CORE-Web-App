namespace ApiaryDiary.Services
{
    using ApiaryDiary.Data.Models;

    using System.Threading.Tasks;

    public interface IApiaryService
    {
        Task<int> CreateAsync(string userId, string name, int capacity);

        Task ViewAll();

        Apiary FindById(int apiaryId);

        Task AddNewLocationAsync(int locationId, int apiaryId);
    }
}
