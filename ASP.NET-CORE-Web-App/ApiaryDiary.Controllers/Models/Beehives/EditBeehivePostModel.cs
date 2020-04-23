namespace ApiaryDiary.Controllers.Models.Beehives
{
    using ApiaryDiary.Data.Models.Enums;

    using static ApiaryDiary.Data.Common.DataConstants.Beehive;
    using System.ComponentModel.DataAnnotations;

    public class EditBeehivePostModel
    {
        public int Id { get; set; }

        [MinLength(BeehiveNumberMinLenght)]
        [MaxLength(BeehiveNumberMinLenght)]
        public int Number { get; set; }

        public SystemType SystemType { get; set; }

        public BeehiveType BeehiveType { get; set; }
    }
}
