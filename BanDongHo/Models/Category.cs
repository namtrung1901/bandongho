using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanDongHo.Models
{
    [Table("Categorys")]
    public class Category
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Slug { get; set; }
        public int ParentId { get; set; }
        public int Orders { get; set; }
        [StringLength(255)]
        public string Metakey { get; set; }
        [StringLength(255)]
        public string Metadesc { get; set; }
        public DateTime? Created_at { get; set; }
        public int? Created_by { get; set; }
        public DateTime? Updated_at { get; set; }
        public int? Updated_by { get; set; }
        public int Status { get; set; }
    }
}