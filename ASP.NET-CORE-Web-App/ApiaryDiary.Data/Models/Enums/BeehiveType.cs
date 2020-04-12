namespace ApiaryDiary.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum BeehiveType
    {
        Beehive = 1,
        [Display(Name ="Royal Family")]
        RoyalFamily = 2,
        Swarm = 3,
        Offspring = 4,
    }
}
