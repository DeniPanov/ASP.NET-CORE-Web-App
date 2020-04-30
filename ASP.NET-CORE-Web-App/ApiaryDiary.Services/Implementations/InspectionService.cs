namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;

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

        private async Task AddInspectionToBeehive(int beehiveId, Inspection inspection)
        {
            var beehive = this.beehiveService.FindById(beehiveId);

            if (beehive == null)
            {
                return;
            }

            beehive.Inspections.Add(inspection);
            await this.db.SaveChangesAsync();
        }
    }
}
