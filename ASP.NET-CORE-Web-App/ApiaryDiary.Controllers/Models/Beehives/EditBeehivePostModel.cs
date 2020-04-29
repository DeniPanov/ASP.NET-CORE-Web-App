namespace ApiaryDiary.Controllers.Models.Beehives
{
    using ApiaryDiary.Data.Models.Enums;

    public class EditBeehivePostModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public SystemType SystemType { get; set; }

        public BeehiveType BeehiveType { get; set; }
    }
}
