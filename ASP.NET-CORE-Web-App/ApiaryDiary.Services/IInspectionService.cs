namespace ApiaryDiary.Services
{
    using ApiaryDiary.Data.Models;
    using ApiaryDiary.Data.Models.Enums;

    using System.Threading.Tasks;

    public interface IInspectionService
    {
        Task<int> CreateAsync(
            int beehiveId, HiveCondition condition, string hygieneLevel,
            int honeyCombsCount, double honeyInKilos, double beehiveWeight, double temperature);

        Inspection FindById(int inspectionId);
    }
}
