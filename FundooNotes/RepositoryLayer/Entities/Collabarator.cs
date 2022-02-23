using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class Collabarator

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CollabId { get; set; }
        public string CollabEmail { get; set; }
        [ForeignKey("Note")]
        public int? NotesId { get; set; }
        public virtual Note notes { get; set; }
        [ForeignKey("User")]
        public int? Userid { get; set; }
        public virtual UserModel Users { get; set; }
    }
}
