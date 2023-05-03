namespace Clothes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASP { get; set; }

        [StringLength(100)]
        public string TENSP { get; set; }

        public decimal? GIABAN { get; set; }

        public decimal? GIAGIAM { get; set; }

        public int? DISCOUNT { get; set; }

        [StringLength(50)]
        public string ANHBIA { get; set; }

        public string MOTA { get; set; }

        public DateTime? NGAYSANXUAT { get; set; }

        [StringLength(50)]
        public string NOISANXUAT { get; set; }

        public int? SL { get; set; }

        public int? MALOAI { get; set; }

        public int? MANCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual LOAISP LOAISP { get; set; }

        public virtual NCC NCC { get; set; }
    }
}
