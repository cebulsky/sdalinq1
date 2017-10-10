namespace LinqConsoleApp.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mecz")]
    public partial class Mecz
    {
        public int ID { get; set; }

        public int ID_Gospodarz { get; set; }

        public int ID_Gosc { get; set; }

        [Required]
        [StringLength(10)]
        public string Wynik { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data_meczu { get; set; }

        public virtual Klub Klub { get; set; }

        public virtual Klub Klub1 { get; set; }
    }
}
