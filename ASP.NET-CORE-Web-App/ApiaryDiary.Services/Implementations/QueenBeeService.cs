namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Controllers.Models.QueenBees;
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;

    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
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
            this.db.SaveChangesAsync().GetAwaiter().GetResult();

            await AddQueenInBeehive(beehive, queen);

            return queen.Id;
        }

        public QueenBee FindById(int id)
        {
            return this.db.QueenBees.Where(q => q.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<AllBeehivesWithQueensServiceViewModel>> GetAllBeehivesWithQueens()
        {
            return await this.db
               .Beehives
               .Where(b => b.HasQueen == true)
               .Select(b => new AllBeehivesWithQueensServiceViewModel
               {
                   ApiaryName = b.Apiary.Name,
                   BeehiveNumber = b.Number,
                   QueenId = b.QueenBees
                            .Select(q => q.Id)
                            .FirstOrDefault(),
                   QueenType = b.QueenBees
                           .Select(q => q.Type)
                           .FirstOrDefault(),
                   QueenCreatedOn = b.QueenBees
                           .Select(q => q.CreatedOn)
                           .FirstOrDefault(),
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<AllBeehivesWithoutQueensServiceViewModel>> GetAllBeehivesWithoutQueens()
        {
            return await this.db
                .Beehives
                .Where(b => b.HasQueen == false)
                .Select(b => new AllBeehivesWithoutQueensServiceViewModel
                {
                    Id = b.Id,
                    ApiaryName = b.Apiary.Name,
                    BeehiveNumber = b.Number,
                    QueenType = b.QueenBees
                           .Select(q => q.Type)
                           .FirstOrDefault(),
                })
                .ToListAsync();
        }

        private async Task AddQueenInBeehive(Beehive beehive, QueenBee queen)
        {
            beehive.HasQueen = true;
            beehive.QueenBees.Add(queen);
            await this.db.SaveChangesAsync();
        }
    }
}
