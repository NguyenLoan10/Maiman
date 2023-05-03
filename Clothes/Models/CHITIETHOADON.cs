namespace Clothes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MADH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASP { get; set; }

        public int? SL { get; set; }

        public decimal? DONGIA { get; set; }

        public int? TongTien { get; set; }

        public virtual DONDATHANG DONDATHANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
