using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoIt.Models
{
    public class Comment : BaseModel
    {
        public int NoteId { get; set; }

        [Required, MinLength(1), MaxLength(400)]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastEditedDate { get; set; }


        public virtual Note Note { get; set; }
    }
}