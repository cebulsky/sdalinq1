namespace LinqConsoleApp.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stadion")]
    public partial class Stadion
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Nazwa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data_budowy { get; set; }

        public int? Ilosc_miejsc { get; set; }

        [StringLength(200)]
        public string Adres { get; set; }

        public int? ID_Klub { get; set; }

        public virtual Klub Klub { get; set; }
    }
}
