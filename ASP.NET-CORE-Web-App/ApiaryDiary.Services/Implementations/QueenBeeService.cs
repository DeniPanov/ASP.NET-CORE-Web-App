namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Controllers.Models.QueenBees;
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;

    using Microsoft.EntityFrameworkCore;

    using System;
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

        public async Task<int> CreateAsync(
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

            beehive.HasQueen = true;

            await this.db.QueenBees.AddAsync(queen);
            this.db.SaveChangesAsync().GetAwaiter().GetResult();

            await AddQueenInBeehive(beehive, queen);

            return queen.Id;
        }

        public async Task DeleteAsync(int queenId)
        {
            var queen = this.FindById(queenId);

            if (queen == null)
            {
                return;
            }

            queen.IsDeleted = true;
            queen.DeletedOn = DateTime.UtcNow;

            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(
            int queenId, QueenBeeType type, string markingColour, string origin, string temper)
        {
            var queen = this.FindById(queenId);

            if (queen == null)
            {
                return;
            }

            queen.Type = type;
            queen.MarkingColour = markingColour;
            queen.Origin = origin;
            queen.Temper = temper;
            queen.ModifiedOn = DateTime.UtcNow;

            await this.db.SaveChangesAsync();
        }

        public QueenBee FindById(int id)
        {
            return this.db.QueenBees.Where(q => q.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<AllBeehivesWithQueensServiceViewModel>> GetAllBeehivesWithQueens()
        {
            return await this.db
               .QueenBees
               .Where(q => q.Beehive.HasQueen == true && q.IsDeleted == false)
               .Select(q => new AllBeehivesWithQueensServiceViewModel
               {
                   Id = q.BeehiveId,
                   ApiaryName = q.Beehive.Apiary.Name,
                   BeehiveNumber = q.Beehive.Number,
                   QueenId = q.Id,
                   QueenType = q.Type,
                   QueenCreatedOn = q.CreatedOn,
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<AllBeehivesWithoutQueensServiceViewModel>> GetAllBeehivesWithoutQueens()
        {
            return await this.db
                .Beehives
                .Where(b => b.HasQueen == false && b.IsDeleted == false)
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
