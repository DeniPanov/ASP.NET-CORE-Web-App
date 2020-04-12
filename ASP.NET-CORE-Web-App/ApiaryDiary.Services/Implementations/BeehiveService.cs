namespace ApiaryDiary.Services.Implementations
{
    using ApiaryDiary.Data;
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;

    using System.Collections.Generic;
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

            for (int i = firstNumber; i <= lastNumber; i++)
            {
                var beehive = new Beehive
                {
                    ApiaryId = apiaryId,
                    Number = i,
                    SystemType = systemType,
                    BeehiveType = beehiveType,
                    IsAlive = true,
                };

                beehives.Add(beehive);
            }

            this.db.Beehives.AddRange(beehives);
            this.db.SaveChanges();
        }
    }
}
