namespace Notebook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Note
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Note()
        {
            Todos = new HashSet<Todo>();
        }

        public int NoteID { get; set; }

        [StringLength(50)]
        public string NoteTitle { get; set; }

        public string NoteContent { get; set; }

        public int? UserID { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Todo> Todos { get; set; }
    }
}
