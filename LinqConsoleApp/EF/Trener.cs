namespace LinqConsoleApp.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trener")]
    public partial class Trener
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trener()
        {
            Klub = new HashSet<Klub>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Imie { get; set; }

        [Required]
        [StringLength(100)]
        public string Nazwisko { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_urodzenia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Klub> Klub { get; set; }
    }
}
