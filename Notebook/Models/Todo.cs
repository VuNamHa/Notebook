namespace Notebook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Todos")]
    public partial class Todo
    {
        public int TodoID { get; set; }

        public int? NoteID { get; set; }

        [StringLength(255)]
        public string TodoMessage { get; set; }

        public bool? DoneStatus { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; }

        public virtual Note Note { get; set; }
    }
}
