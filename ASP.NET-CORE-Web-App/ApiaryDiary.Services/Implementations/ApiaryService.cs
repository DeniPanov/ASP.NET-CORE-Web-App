namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class ApiaryService : IApiaryService
    {
        private readonly ApiaryDiaryDbContext db;
        private readonly ILocationInfoService locationInfoService;

        public ApiaryService(
            ApiaryDiaryDbContext db,
            ILocationInfoService locationInfoService)
        {
            this.db = db;
            this.locationInfoService = locationInfoService;
        }

        public async Task<int> CreateAsync(
            string userId,
            string apiaryName,
            int capacity)
        {
            var apiary = new Apiary
            {
                ApplicationUserId = userId,
                Name = apiaryName,
                Capacity = capacity,
            };

            await db.Apiaries.AddAsync(apiary);
            await db.SaveChangesAsync();

            return apiary.Id;
        }

        public async Task ViewAll()
        {
            await Task.CompletedTask;
        }

        public async Task AddNewLocationAsync(int locationId, int apiaryId)
        {
            var currentApiary = this.FindById(apiaryId);
            var currentLocation = this.locationInfoService.FindById(locationId);
            currentApiary.Locations.Add(currentLocation);
            await db.SaveChangesAsync();
        }

        public Apiary FindById(int apiaryId)
        {
            return db.Apiaries
                .Where(a => a.Id == apiaryId)
                .FirstOrDefault();
        }
    }
}
