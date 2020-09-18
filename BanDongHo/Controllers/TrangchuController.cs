using BanDongHo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BanDongHo.Controllers
{
    public class TrangchuController : Controller
    {
        BanDongHoDBContext db = new BanDongHoDBContext();
        //
        // GET: /Trangchu/
        public ActionResult Index()
        {
            //var listcat = db.Categorys.Where(m => m.Status == 1 && m.ParentId == 0).ToList();
            var model = db.Products.Where(m => m.Status == 1).OrderBy(m=>m.Created_at).ToList();
            return View();
        }

        public ActionResult HomeProduct(int? page)
        {
            //List<int> catlist = db.Categorys.Where(m => m.ParentId == catid).Select(m => m.Id).ToList();
            //catlist.Add(catid);
            int pageSize = 6;
            int pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var model = db.Products.Where(m => m.Status == 1).OrderByDescending(m => m.Created_at).ToPagedList(pageIndex,pageSize);
            return View("_HomeProduct", model);
        }

        public ActionResult PromotionProduct()
        {
            var model = db.Products.Where(m => m.Status == 1 && m.Price_sale != 0).OrderByDescending(m=>m.Created_at).Take(6).ToList();
            return View("_PromotionProduct", model);
        }
    }
}