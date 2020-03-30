namespace ApiaryDiary.Services.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;

    using static ApiaryDiary.Data.Common.DataConstants.Apiary;

    public class ApiaryService : IApiaryService
    {
        private readonly ApiaryDiaryDbContext db;

        public ApiaryService(ApiaryDiaryDbContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(string apiaryName, int capacity)
        {
            if (string.IsNullOrWhiteSpace(apiaryName)
              || apiaryName.Length < ApiaryNameMinLenght
              || apiaryName.Length > ApiaryNameMaxLenght
              || capacity < ApiaryCapacityMinLenght
              || capacity > ApiaryCapacityMaxLenght)
            {
                return 0;
            }

            var apiary = new Apiary
            {
                Name = apiaryName,
                Capacity = capacity,
            };

            db.Apiaries.Add(apiary);

            await db.SaveChangesAsync();

            return apiary.Id;
        }

        public async Task ViewAll()
        {
            await Task.CompletedTask;
        }
    }
}
