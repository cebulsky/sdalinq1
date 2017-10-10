namespace LinqConsoleApp.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zawodnik")]
    public partial class Zawodnik
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Imie { get; set; }

        [Required]
        [StringLength(100)]
        public string Nazwisko { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_urodzenia { get; set; }

        [Required]
        [StringLength(50)]
        public string Pozycja { get; set; }

        [Column(TypeName = "money")]
        public decimal Pensja_roczna { get; set; }

        public int? ID_Klub { get; set; }

        public virtual Klub Klub { get; set; }
    }
}
