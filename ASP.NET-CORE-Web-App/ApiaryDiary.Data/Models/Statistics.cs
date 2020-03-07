namespace ApiaryDiary.Data.Models
{
    public class Statistics
    {
        public int Id { get; set; }

        public virtual Beehive Beehive { get; set; }

        public int BeehiveId { get; set; }
    }
}
