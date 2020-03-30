namespace ApiaryDiary.Services
{
    using System.Threading.Tasks;

    public interface IApiaryService
    {
        Task<int> CreateAsync(string name, int capacity);

        Task ViewAll();
    }
}
