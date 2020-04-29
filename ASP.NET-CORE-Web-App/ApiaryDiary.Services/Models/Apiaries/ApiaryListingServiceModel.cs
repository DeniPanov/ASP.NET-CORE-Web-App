namespace ApiaryDiary.Services.Models.Apiaries
{
    public class ApiaryListingServiceModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public int TotalBeehives { get; set; }

        public string Address { get; set; }
    }
}
