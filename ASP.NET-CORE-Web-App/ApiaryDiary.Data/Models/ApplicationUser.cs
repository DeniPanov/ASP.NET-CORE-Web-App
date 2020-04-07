namespace ApiaryDiary.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            
            Apiaries = new HashSet<Apiary>();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual Notebook Notebook { get; set; }

        public int NotebookId { get; set; }

        public virtual ICollection<Apiary> Apiaries { get; set; }
    }
}
