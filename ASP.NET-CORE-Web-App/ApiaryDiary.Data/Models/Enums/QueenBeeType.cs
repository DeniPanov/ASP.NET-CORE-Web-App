using System.ComponentModel.DataAnnotations;

namespace ApiaryDiary.Data.Models.Enums
{
    public enum QueenBeeType
    {
        Swarm = 1, //Роева
        [Display(Name = "Forced Change")]
        ForcedChange = 2, //Свещева
        [Display(Name = "Self Change")]
        SelfChange = 3, //Самосменна
        [Display(Name = "Moving Larva")]
        MovingLarva = 4, //От личинка
        NoMother = 9,
    }
}