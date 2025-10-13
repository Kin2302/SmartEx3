namespace SmartEx3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        // ID danh m?c (Primary Key, t? ??ng t?ng)
        public int CategoryId { get; set; }

        // Tên danh m?c - B?t bu?c, t?i ?a 100 ký t?
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
