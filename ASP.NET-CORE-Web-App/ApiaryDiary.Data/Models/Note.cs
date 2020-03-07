namespace ApiaryDiary.Data.Models
{
    using System;
    
    public class Note
    {
        public Note()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public virtual Notebook Notebook { get; set; }

        public int NotebookId { get; set; }
    }
}