using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;

namespace BanDongHo.Controllers
{
    public class GiohangController : Controller
    {
        BanDongHoDBContext db = new BanDongHoDBContext();
        // GET: Giohang
        public ActionResult Index()
        {
            List<Cart> lstGioHang = Laygiohang();
            return View(lstGioHang);
        }

        public List<Cart> Laygiohang()
        {
            List<Cart> lstGioHang = Session["cart"] as List<Cart>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<Cart>();
                Session["cart"] = lstGioHang;
            }
            return lstGioHang;
        }
        public int Tongsoluong()
        {
            int Tongsoluong = 0;
            List<Cart> lstGioHang = Session["cart"] as List<Cart>;
            if (lstGioHang != null)
            {
                Tongsoluong = lstGioHang.Sum(n => n.Quantity);
            }
            return Tongsoluong;
        }

        public double Tongtien()
        {
            double Tongtien = 0;
            List<Cart> lstGioHang = Session["cart"] as List<Cart>;
            if (lstGioHang != null)
            {
                Tongtien = lstGioHang.Sum(n => n.Amount);
            }
            return Tongtien;
        }
        public ActionResult AddCart(int Masp, string strURL)
        {
            Product product = db.Products.SingleOrDefault(n => n.Id == Masp);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Cart> lstGioHang = Laygiohang();
            Cart gh = lstGioHang.SingleOrDefault(n => n.Id == Masp);
            if (gh == null)
            {
                gh = new Cart(Masp);
                lstGioHang.Add(gh);
                return Redirect(strURL);
            }
            else
            {
                gh.Quantity++;
                return Redirect(strURL);
            }
        }

        public ActionResult EditNum(Cart lstCart)
        {
            List<Cart> lstGH = Laygiohang();
            Cart updategh = lstGH.Find(m => m.Id == lstCart.Id);
            updategh.Quantity = lstCart.Quantity;

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Masp)
        {
            Product product = db.Products.SingleOrDefault(n => n.Id == Masp);
            List<Cart> giohang = Session["cart"] as List<Cart>;
            Cart itemXoa = giohang.FirstOrDefault(m => m.Id == Masp);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DatHang(Customer cus)
        {
            if(Session["cart"] == null)
            {
                return RedirectToAction("Index", "Trangchu");
            }
            Customer kh = new Customer();
            if (Session["UserName"] == null)
            {
                kh = cus;
                db.Customers.Add(kh);
                db.SaveChanges();
            }
            else
            {
                User user = Session["UserName"] as User;
                kh.UserId = user.Id;
                kh.FullName = cus.FullName;
                kh.Email = user.Email;
                kh.Address = cus.Address;
                kh.Phone = cus.Phone;
                db.Customers.Add(kh);
                db.SaveChanges();
            }

            Order ddh = new Order();
            ddh.CustemerId = kh.Id;
            ddh.CreateDate = DateTime.Now;
            ddh.ExportDate = DateTime.Now;
            ddh.Status = 0;
            ddh.DeliveryAddress = kh.Address;
            ddh.DeliveryName = "";
            db.Orders.Add(ddh);
            db.SaveChanges();
            List<Cart> lstCart = Laygiohang();
            foreach(var item in lstCart)
            {
                Orderdetail ctdh = new Orderdetail();
                ctdh.OrderId = ddh.Id;
                ctdh.ProductId = item.Id;
                ctdh.ProductName = item.Name;
                ctdh.Quantity = item.Quantity;
                ctdh.Price = item.Price;
                ctdh.Amount = item.Amount;
                db.Orderdetails.Add(ctdh);
            }
            db.SaveChanges();
            Session["cart"] = null;
            return RedirectToAction("Index");
        }
    }
}