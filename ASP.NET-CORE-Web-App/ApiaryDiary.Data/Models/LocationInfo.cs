namespace ApiaryDiary.Data.Models
{
    public class LocationInfo
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public int Altitude { get; set; }

        public bool HasHoneyPlants { get; set; }

        public Apiary Apiary { get; set; }

        public int ApiaryId { get; set; }

        //TODO: consider adding outdoorType or something similar
    }
}
