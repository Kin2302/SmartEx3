namespace SmartEx3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Transactions = new HashSet<Transaction>();
        }

        // ID ng??i dùng (Primary Key, t? ??ng t?ng)
        public int UserId { get; set; }

        // Tên hi?n th? c?a ng??i dùng - B?t bu?c, t?i ?a 100 ký t?
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // ??a ch? email (dùng ?? ??ng nh?p) - B?t bu?c, t?i ?a 255 ký t?, ph?i unique
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        // M?t kh?u ?ã ???c hash (SHA256) - B?t bu?c, t?i ?a 512 ký t?
        [Required]
        [StringLength(512)]
        public string PasswordHash { get; set; }

        // Salt dùng ?? hash m?t kh?u - B?t bu?c, t?i ?a 128 ký t?
        [Required]
        [StringLength(128)]
        public string Salt { get; set; }

        // Thu nh?p hàng tháng c?a ng??i dùng (VN?) - Tùy ch?n
        public decimal? Income { get; set; }

        // M?c tiêu ti?t ki?m c?a ng??i dùng (VN?) - Tùy ch?n
        public decimal? Goal { get; set; }

        // Ngày t?o tài kho?n - T? ??ng ??t khi t?o user m?i
        [Column(TypeName = "datetime2")]
        public DateTime? CreatedAt { get; set; }

        // Collection các giao d?ch c?a ng??i dùng
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
