using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanDongHo.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Slug { get; set; }
        [StringLength(255)]
        public string Img { get; set; }
        [StringLength(255)]
        public string Detail { get; set; }
        public int Number { get; set; }
        public float Price { get; set; }
        public float Price_sale { get; set; }
        public string Metakey { get; set; }
        public string Metadesc { get; set; }
        public DateTime Created_at { get; set; }
        public int Created_by { get; set; }
        public DateTime Updated_at { get; set; }
        public int Updated_by { get; set; }
        public int Status { get; set; }
    }
}