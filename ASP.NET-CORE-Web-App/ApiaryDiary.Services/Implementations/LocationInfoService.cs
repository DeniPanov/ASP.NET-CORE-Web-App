namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;

    using System.Linq;
    using System.Threading.Tasks;

    public class LocationInfoService : ILocationInfoService
    {
        private readonly ApiaryDiaryDbContext db;

        public LocationInfoService(ApiaryDiaryDbContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(int apiryId, string settlement)
        {
            var location = new LocationInfo
            {
                Settlement = settlement,
                ApiaryId = apiryId
            };

            db.Locations.Add(location);
            await db.SaveChangesAsync();

            return location.Id;
        }

        public LocationInfo FindById(int locationId)
        {
            return db.Locations
                .Where(l => l.Id == locationId)
                .FirstOrDefault();
        }
    }
}
