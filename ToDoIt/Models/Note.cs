using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoIt.Models
{
    public class Note : BaseModel
    {
        [Required, MinLength(1), MaxLength(20)]
        public string Title { get; set; }

        [Required, MinLength(1), MaxLength(400)]
        public string Content { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }


        public virtual List<Comment> Comments { get; set; }
    }
}