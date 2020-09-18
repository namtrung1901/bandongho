using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;
using PagedList;

namespace BanDongHo.Controllers
{
    public class TimkiemController : Controller
    {
        BanDongHoDBContext db = new BanDongHoDBContext();
        // GET: Timkiem
        public ActionResult KetQua(string skey, int? page)
        {
            int pageSize = 12;
            int pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var lstSP = db.Products.Where(m => m.Status == 1 && m.Name.Contains(skey));
            ViewBag.TuKhoa = skey;
            return View(lstSP.OrderBy(m=>m.Name).ToPagedList(pageIndex,pageSize));
        }
    }
}