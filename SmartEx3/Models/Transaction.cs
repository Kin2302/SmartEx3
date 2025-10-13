namespace SmartEx3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        // ID giao d?ch (Primary Key, t? ??ng t?ng)
        [Key]
        public int TransId { get; set; }

        // ID ng??i dùng (Foreign Key ??n b?ng Users)
        public int UserId { get; set; }

        // S? ti?n giao d?ch (VN?) - Giá tr? d??ng: Thu nh?p, Giá tr? âm: Chi tiêu
        public decimal Amount { get; set; }

        // Danh m?c giao d?ch - B?t bu?c v?i chi tiêu, Tùy ch?n v?i thu nh?p
        [StringLength(100)]
        public string Category { get; set; }

        // Ghi chú chi ti?t v? giao d?ch - Tùy ch?n, t?i ?a 500 ký t?
        [StringLength(500)]
        public string Note { get; set; }

        // Ngày th?c hi?n giao d?ch
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        // Ngày t?o b?n ghi trong h? th?ng
        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        // Thông tin ng??i dùng s? h?u giao d?ch
        public virtual User User { get; set; }
    }
}
