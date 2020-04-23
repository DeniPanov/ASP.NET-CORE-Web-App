namespace ApiaryDiary.Services.Models
{
    using ApiaryDiary.Data.Models.Enums;

    using System.ComponentModel.DataAnnotations;

    public class BeehiveDetailsServiceModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public string CreatedOn { get; set; }

        public string ApiaryName { get; set; }

        public int Number { get; set; }

        public string Location { get; set; }

        public SystemType SystemType { get; set; }

        public BeehiveType BeehiveType { get; set; }

        public QueenBeeType QueenType { get; set; }
    }
}
