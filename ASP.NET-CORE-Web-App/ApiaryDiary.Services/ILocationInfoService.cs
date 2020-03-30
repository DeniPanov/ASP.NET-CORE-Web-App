namespace ApiaryDiary.Services
{
    using System.Threading.Tasks;

    public interface ILocationInfoService
    {
        Task<int> CreateAsync(string settlement);
    }
}
