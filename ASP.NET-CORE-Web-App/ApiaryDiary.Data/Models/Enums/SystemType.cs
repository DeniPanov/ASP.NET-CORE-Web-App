namespace ApiaryDiary.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum SystemType
    {
        [Display(Name = "Dadant Blatt")]
        Dadant_Blatt = 1,
        [Display(Name = "Langstroth Ruth")]
        Langstroth_Ruth = 2,
        Farrar = 3,
        [Display(Name = "Roger Delon")]
        Roger_Delon = 4,
        Polystyrene = 5,
        Modular = 6,
        Other = 9,
    }
}
