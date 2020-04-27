namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;
    using ApiaryDiary.Services.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task AddNewLocationAsync(int locationId, int apiaryId)
        {
            var currentApiary = this.FindById(apiaryId);
            var currentLocation = this.locationInfoService.FindById(locationId);
            currentApiary.Locations.Add(currentLocation);
            await db.SaveChangesAsync();
        }

        public int ApiariesCount()
        {
            return this.db.Apiaries.Count();
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

        public async Task DeleteAsync(int apiaryId)
        {
            var apiary = this.FindById(apiaryId);

            if (apiary == null)
            {
                return;
            }

            apiary.IsDeleted = true;
            apiary.DeletedOn = DateTime.UtcNow;

            await db.SaveChangesAsync();
        }

        public async Task<ApiaryDetailsServiceModel> DetailsAsync(int apiaryId)
        {
            return await this.db
                .Apiaries
                .Where(a => a.Id == apiaryId)
                .Select(a => new ApiaryDetailsServiceModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    BeekeepingType = a.BeekeepingType,
                    Capacity = a.Capacity,
                    CreatedOn = a.CreatedOn.ToString("r"),
                    BeehivesCount = a.Beehives.Count(),
                })
                .FirstOrDefaultAsync();
        }

        public async Task EditAsync(
            int apiaryId,
            string name,
            BeekeepingType BeekeepingType,
            int capacity)
        {
            var apiary = this.FindById(apiaryId);

            if (apiary == null)
            {
                return;
            }

            apiary.Name = name;
            apiary.BeekeepingType = BeekeepingType;
            apiary.Capacity = capacity;
            apiary.ModifiedOn = DateTime.UtcNow;

            await this.db.SaveChangesAsync();
        }

        public Apiary FindById(int apiaryId)
        {
            return db.Apiaries
                .Where(a => a.Id == apiaryId)
                .FirstOrDefault();
        }

        public IEnumerable<SelectListItem> GetAll(string userId)
        {
            var apiaries = this.db
                .Apiaries
                .Where(a => a.ApplicationUserId == userId && a.IsDeleted == false)
                .ToList();

            var listItems = new List<SelectListItem>();

            foreach (var apiary in apiaries)
            {
                listItems.Add(new SelectListItem
                {
                    Value = apiary.Id.ToString(),
                    Text = apiary.Name
                });
            }

            return listItems;
        }

        public async Task<IEnumerable<ApiaryListingServiceModel>> ViewAllAsync()
        {
            return await db.Apiaries
                .Where(a => a.IsDeleted == false)
                .Select(x => new ApiaryListingServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    TotalBeehives = x.Beehives.Count(),
                    Address = x.Locations
                            .Select(l => l.Settlement)
                            .FirstOrDefault()
                })
                .OrderBy(x => x.TotalBeehives)
                .ToListAsync();
        }
    }
}
