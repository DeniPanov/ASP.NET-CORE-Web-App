namespace ApiaryDiary.Data.Models
{
    using System;
    
    public class Note
    {
        public int Id { get; set; }

        public DateTime CreationDate => DateTime.UtcNow;

        public string Content { get; set; }

        public Notebook Notebook { get; set; }

        public int NotebookId { get; set; }
    }
}