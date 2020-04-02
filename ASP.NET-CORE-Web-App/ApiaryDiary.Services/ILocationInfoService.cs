namespace ApiaryDiary.Services
{
    using ApiaryDiary.Data.Models;

    using System.Threading.Tasks;

    public interface ILocationInfoService
    {
        Task<int> CreateAsync(int apiryId, string settlement);

        LocationInfo FindById(int locationId);
    }
}
