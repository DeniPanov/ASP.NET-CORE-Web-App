namespace ApiaryDiary.Data.Models
{
    using System.Collections.Generic;

    public class Notebook
    {
        public Notebook()
        {
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
