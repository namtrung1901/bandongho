using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanDongHo.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public int CustemerId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExportDate { get; set; }
        [StringLength(255)]
        public string DeliveryAddress { get; set; }
        [StringLength(255)]
        public string DeliveryName { get; set; }
        public int Status { get; set; }
    }
}