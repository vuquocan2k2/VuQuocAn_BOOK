namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Tua sach khong duoc de trong")]
        [StringLength(150, ErrorMessage = "Tua sach co toi da 150 ki tu")]
        public string Title { get; set; }

        [StringLength(150, ErrorMessage = "Ten tac gia co toi da 150 ki tu")]
        public string Author { get; set; }
        [Range(1,99999999,ErrorMessage ="Gia sach tu 1-9999999999")]

        public decimal? Price { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
