namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;
    using ApiaryDiary.Services.Models;

    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BeehiveService : IBeehiveService
    {
        private readonly ApiaryDiaryDbContext db;

        public BeehiveService(ApiaryDiaryDbContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(
            int apiaryId,
            int number,
            SystemType systemType,
            BeehiveType beehiveType)
        {
            var beehive = new Beehive
            {
                ApiaryId = apiaryId,
                Number = number,
                SystemType = systemType,
                BeehiveType = beehiveType,
                IsAlive = true,
            };

            await this.db.Beehives.AddAsync(beehive);
            await this.db.SaveChangesAsync();

            return beehive.Id;
        }

        public void CreateMultiple(
            int apiaryId,
            int firstNumber,
            int lastNumber,
            SystemType systemType,
            BeehiveType beehiveType)
        {
            var beehives = new List<Beehive>();

            for (int number = firstNumber; number <= lastNumber; number++)
            {
                var beehive = new Beehive
                {
                    ApiaryId = apiaryId,
                    Number = number,
                    SystemType = systemType,
                    BeehiveType = beehiveType,
                    IsAlive = true,
                };

                beehives.Add(beehive);
            }

            this.db.Beehives.AddRange(beehives);
            this.db.SaveChanges();
        }

        public void Delete(int beehiveId)
        {
            var beehiveToDelete = this.FindById(beehiveId);

            if (beehiveToDelete == null)
            {
                return;
            }

            beehiveToDelete.IsDeleted = true;
            beehiveToDelete.DeletedOn = DateTime.UtcNow;

            this.db.SaveChanges();
        }

        public async Task DeleteAllBeehivesInApiary(int apiaryId)
        {
            List<Beehive> beehivesToDelete = GetAllBeehives(apiaryId);

            foreach (var beehive in beehivesToDelete)
            {
                beehive.IsDeleted = true;
            }

            await this.db.SaveChangesAsync();
        }

        public async Task<BeehiveDetailsServiceModel> DetailsAsync(int beehiveId)
        {
            return await this.db
                .Beehives
                .Where(b => b.Id == beehiveId)
                .Select(b => new BeehiveDetailsServiceModel
                {
                    Id = b.Id,
                    CreatedOn = b.CreatedOn.ToString("r"),
                    Number = b.Number,
                    ApiaryName = b.Apiary.Name,
                    Location = b.Apiary.Locations
                            .Select(l => l.Settlement)
                            .FirstOrDefault(),
                    SystemType = b.SystemType,
                    BeehiveType = b.BeehiveType,
                    QueenType = b.QueenBees.Select(q => q.Type).FirstOrDefault()
                })
                .FirstOrDefaultAsync();
        }

        public async Task EditAsync(
            int beehiveId,
            int number,
            SystemType systemType,
            BeehiveType beehiveType)
        {
            var beehive = this.FindById(beehiveId);

            if (beehive == null)
            {
                return;
            }

            beehive.Number = number;
            beehive.SystemType = systemType;
            beehive.BeehiveType = beehiveType;
            beehive.ModifiedOn = DateTime.UtcNow;

            await this.db.SaveChangesAsync();
        }

        public Beehive FindById(int beehiveId)
        {
            return this.db.Beehives.Where(b => b.Id == beehiveId).FirstOrDefault();
        }

        public async Task<IEnumerable<BeehiveListingServiceModel>> ViewAllAsync()
        {
            return await this.db
                .Beehives
                .Where(x => x.IsDeleted == false)
                .Select(b => new BeehiveListingServiceModel
                {
                    Id = b.Id,
                    CreatedOn = b.CreatedOn,
                    Number = b.Number,
                    ApiaryName = b.Apiary.Name,
                    Location = b.Apiary.Locations
                                    .Select(l => l.Settlement)
                                    .FirstOrDefault(),
                    QueenBeeType = b.QueenBees
                                    .Select(q => q.Type)
                                    .FirstOrDefault(),
                    SystemType = b.SystemType,
                    BeehiveType = b.BeehiveType,
                })
                .OrderBy(x => x.ApiaryName)
                .ThenBy(x => x.CreatedOn)
                .ToListAsync();
        }

        private List<Beehive> GetAllBeehives(int apiaryId)
        {
            return this.db
                .Beehives
                .Where(b => b.ApiaryId == apiaryId)
                .ToList();
        }
    }
}
