namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? num { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string prode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string billcode { get; set; }

        public DateTime time { get; set; }

        public virtual Product Product { get; set; }

        public virtual Product Product1 { get; set; }
    }
}
