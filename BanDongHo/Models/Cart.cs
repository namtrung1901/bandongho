using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanDongHo.Models
{
    public class Cart
    {
        BanDongHoDBContext db = new BanDongHoDBContext();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Amount
        {
            get { return Quantity * Price; }
        }
        public double Tax
        {
            get { return Amount * 0.1; }
        }
        public double Total
        { get { return Amount + Tax; } }
        public Cart(int Masp)
        {
            this.Id = Masp;
            Product product = db.Products.Single(n => n.Id == Masp);
            this.Name = product.Name;
            this.Img = product.Img;
            if(product.Price_sale == 0)
            {
                this.Price = product.Price;
            }
            else
            {
                this.Price = product.Price_sale;
            }
            
            this.Quantity = 1;
        }
        public Cart(int Masp, int sl)
        {
            this.Id = Masp;
            Product product = db.Products.Single(n => n.Id == Masp);
            this.Name = product.Name;
            this.Img = product.Img;
            if (product.Price_sale == 0)
            {
                this.Price = product.Price;
            }
            else
            {
                this.Price = product.Price_sale;
            }
            this.Quantity = sl;
        }
        public Cart()
        {

        }
    }
}