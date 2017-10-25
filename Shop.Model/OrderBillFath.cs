namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderBillFath")]
    public partial class OrderBillFath
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderBillFath()
        {
            OrderBillChi = new HashSet<OrderBillChi>();
            OrderBillChi1 = new HashSet<OrderBillChi>();
        }

        [Key]
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string cusid { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        public DateTime time { get; set; }

        [Column(TypeName = "money")]
        public decimal? totalprice { get; set; }

        [StringLength(50)]
        public string paymethod { get; set; }

        public DateTime paytime { get; set; }

        public DateTime posttime { get; set; }

        public DateTime rectime { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderBillChi> OrderBillChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderBillChi> OrderBillChi1 { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
