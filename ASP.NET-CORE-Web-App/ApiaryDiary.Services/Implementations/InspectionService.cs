namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;
    using ApiaryDiary.Services.Models.Inspections;

    using Microsoft.EntityFrameworkCore;

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class InspectionService : IInspectionService
    {
        private readonly ApiaryDiaryDbContext db;
        private readonly IBeehiveService beehiveService;

        public InspectionService(
            ApiaryDiaryDbContext db,
            IBeehiveService beehiveService)
        {
            this.db = db;
            this.beehiveService = beehiveService;
        }

        public async Task<int> CreateAsync(
            int beehiveId, HiveCondition condition, string hygieneLevel,
            int honeyCombsCount, double honeyInKilos, double beehiveWeight, double temperature)
        {
            var inspection = new Inspection
            {
                BeehiveId = beehiveId,
                HiveCondition = condition,
                HygieneLevel = hygieneLevel,
                HoneyCombsCount = honeyCombsCount,
                HoneyInKilos = honeyInKilos,
                BeehiveWeight = beehiveWeight,
                Temperature = temperature,
                IsInspected = true,
            };

            this.db.Inspections.Add(inspection);
            await this.db.SaveChangesAsync();

            await this.AddInspectionToBeehive(beehiveId, inspection);

            return inspection.Id;
        }

        public Inspection FindById(int inspectionId)
        {
            return db.Inspections
                .Where(i => i.Id == inspectionId)
                .FirstOrDefault();
        }

        public async Task<IEnumerable<InspectedHivesListingServiceModel>> GetAllInspectedHives()
        {
            return await this.db
               .Inspections
               .Where(i => i.IsDeleted == false && i.IsInspected == true)
               .Select(i => new InspectedHivesListingServiceModel
               {
                   Id = i.Id,
                   BeehiveId = i.Beehive.Id,
                   BeehiveNumber = i.Beehive.Number,
                   HiveCondition = i.HiveCondition,
                   HygieneLevel = i.HygieneLevel,
                   HoneyCombsCount = i.HoneyCombsCount,
                   HoneyInKilos = i.HoneyInKilos,
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<UninspectedHivesListingServiceModel>> GetAllUninspectedHives()
        {
            return await this.db
               .Beehives
               .Where(b => b.IsDeleted == false && b.IsInspected == false)
               .Select(b => new UninspectedHivesListingServiceModel
               {
                   //Id = i.Id,
                   BeehiveId = b.Id,
                   BeehiveNumber = b.Number,
                   HiveCondition = b.Inspections.FirstOrDefault().HiveCondition,
               })
               .ToListAsync();
        }

        private async Task AddInspectionToBeehive(int beehiveId, Inspection inspection)
        {
            var beehive = this.beehiveService.FindById(beehiveId);

            if (beehive == null)
            {
                return;
            }

            beehive.IsInspected = true;
            beehive.Inspections.Add(inspection);
            await this.db.SaveChangesAsync();
        }
    }
}
