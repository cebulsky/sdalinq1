namespace LinqConsoleApp.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fanklub")]
    public partial class Fanklub
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string Nazwa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data_powstania { get; set; }

        public int? Ilosc_czlonkow { get; set; }

        public int? ID_Klub { get; set; }

        public virtual Klub Klub { get; set; }
    }
}
