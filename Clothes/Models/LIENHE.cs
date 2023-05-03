namespace Clothes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LIENHE")]
    public partial class LIENHE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MALIENHE { get; set; }

        [StringLength(100)]
        public string HOTEN { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(100)]
        public string CHUDE { get; set; }

        [StringLength(100)]
        public string NOIDUNG { get; set; }
    }
}
