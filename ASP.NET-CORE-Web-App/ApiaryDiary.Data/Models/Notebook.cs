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

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
