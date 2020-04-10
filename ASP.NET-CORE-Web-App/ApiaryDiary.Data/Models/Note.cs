namespace ApiaryDiary.Data.Models
{
    using static Common.DataConstants.Note;

    using System;
    using System.ComponentModel.DataAnnotations;

    public class Note
    {
        public Note()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [MaxLength(NoteMaxLenght)]
        public string Content { get; set; }

        public virtual Notebook Notebook { get; set; }

        public int NotebookId { get; set; }
    }
}