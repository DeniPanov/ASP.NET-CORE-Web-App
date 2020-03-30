namespace ApiaryDiary.Services.Implementations
{
    using System.Threading.Tasks;

    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;

    using static ApiaryDiary.Data.Common.DataConstants.LocationInfo;

    public class LocationInfoService : ILocationInfoService
    {
        private readonly ApiaryDiaryDbContext db;

        public LocationInfoService(ApiaryDiaryDbContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(string settlement)
        {
            if (string.IsNullOrWhiteSpace(settlement)
              || settlement.Length > SettlementMaxLenght)
            {
                return 0;
            }

            var location = new LocationInfo
            {
                Settlement = settlement
            };

            if (location == null)
            {
                return 0;
            }

            db.Locations.Add(location);
            await db.SaveChangesAsync();

            return location.Id;
        }
    }
}
