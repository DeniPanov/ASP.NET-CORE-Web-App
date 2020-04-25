namespace ApiaryDiary.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum QueenBeeType
    {
        [Display(Name = "No mother")]
        NoMother = 0,
        Swarm = 1, //Роева
        [Display(Name = "Forced Change")]
        ForcedChange = 2, //Свещева
        [Display(Name = "Self Change")]
        SelfChange = 3, //Самосменна
        [Display(Name = "Moving Larva")]
        MovingLarva = 4, //От личинка
    }
}