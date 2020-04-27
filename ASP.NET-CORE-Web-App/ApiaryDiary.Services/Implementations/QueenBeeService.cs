namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;

    using System.Linq;
    using System.Threading.Tasks;

    public class QueenBeeService : IQueenBeeService
    {
        private readonly ApiaryDiaryDbContext db;
        private readonly IBeehiveService beehiveService;

        public QueenBeeService(
            ApiaryDiaryDbContext db,
            IBeehiveService beehiveService)
        {
            this.db = db;
            this.beehiveService = beehiveService;
        }

        public async Task<int> Create(
            int beehiveId,
            QueenBeeType queenType,
            string markingColour,
            string origin,
            string temper)
        {
            var beehive = this.beehiveService.FindById(beehiveId);

            var queen = new QueenBee
            {
                BeehiveId = beehiveId,
                Type = queenType,
                MarkingColour = markingColour,
                Origin = origin,
                Temper = temper,
            };

            await this.db.QueenBees.AddAsync(queen);
            await this.db.SaveChangesAsync();

            await AddQueenInBeehive(beehive, queen);

            return queen.Id;
        }     

        public QueenBee FindById(int id)
        {
            return this.db.QueenBees.Where(q => q.Id == id).FirstOrDefault();
        }

        private async Task AddQueenInBeehive(Beehive beehive, QueenBee queen)
        {
            beehive.QueenBees.Add(queen);
            await this.db.SaveChangesAsync();
        }
    }
}
