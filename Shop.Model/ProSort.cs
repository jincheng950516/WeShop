namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProSort")]
    public partial class ProSort
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string SortCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ProCode { get; set; }

        public virtual Product Product { get; set; }

        public virtual Sort Sort { get; set; }

        public virtual Sort Sort1 { get; set; }

        public virtual Sort Sort2 { get; set; }
    }
}
