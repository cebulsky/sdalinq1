namespace LinqConsoleApp.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klub")]
    public partial class Klub
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klub()
        {
            Fanklub = new HashSet<Fanklub>();
            Mecz = new HashSet<Mecz>();
            Mecz1 = new HashSet<Mecz>();
            Stadion = new HashSet<Stadion>();
            Zawodnik = new HashSet<Zawodnik>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nazwa { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_zalozenia { get; set; }

        [Column(TypeName = "money")]
        public decimal Budzet_roczny { get; set; }

        public int ID_Trener { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fanklub> Fanklub { get; set; }

        public virtual Trener Trener { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mecz> Mecz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mecz> Mecz1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stadion> Stadion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zawodnik> Zawodnik { get; set; }
    }
}
