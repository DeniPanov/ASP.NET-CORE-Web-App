namespace ApiaryDiary.Data.Models
{
    public class LocationInfo
    {
        public int Id { get; set; }

        public string Town { get; set; }

        public int Altitude { get; set; }

        public bool HasHoneyPlants { get; set; }

        //TODO: consider adding outdoorType or something similar
    }
}
