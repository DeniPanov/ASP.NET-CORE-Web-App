namespace ApiaryDiary.Services.Models
{
    using ApiaryDiary.Data.Models.Enums;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class BeehiveListingServiceModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        public int Number { get; set; }

        public string ApiaryName { get; set; }

        public string Location { get; set; }

        public QueenBeeType QueenBeeType { get; set; }

        public SystemType SystemType { get; set; }

        public BeehiveType BeehiveType { get; set; }
    }
}