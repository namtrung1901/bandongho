using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;
using PagedList;

namespace BanDongHo.Controllers
{
    public class SanphamController : Controller
    {
        BanDongHoDBContext db = new BanDongHoDBContext();
        // GET: Sanpham
        public PartialViewResult Index(int? page)
        {
            int pageSize = 12;
            int pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var pro = db.Products.Where(m => m.Status == 1)
                .OrderByDescending(m => m.Created_at).ToPagedList(pageIndex, pageSize);
            return PartialView(pro);
        }

        public PartialViewResult Category(string slugcat, int? page)
        {
            var rowcat = db.Categorys.Where(m => m.Slug == slugcat).First();
            int catid = rowcat.Id;
            ViewBag.title = rowcat.Name;
            List<int> listcatid = db.Categorys
                .Where(m => m.Status == 1 && m.ParentId == catid).Select(m => m.Id).ToList();
            listcatid.Add(catid);
            ViewBag.Slug = catid.ToString();
            int pageSize = 12;
            int pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var pro = db.Products.Where(m => m.Status == 1 && listcatid.Contains(m.CatId))
                .OrderByDescending(m => m.Created_at).ToPagedList(pageIndex, pageSize);
            return PartialView(pro);
        }

        public ActionResult ProductDetail(string slug)
        {
            var product = db.Products.Where(m=>m.Slug == slug).First();
            var pro = db.Products.Where(m => m.Slug != slug && m.CatId == product.CatId).ToList();
            ViewBag.lstRelated = pro;
            var model = db.Products.Where(m => m.Status == 1 && m.Slug == slug).First();
            return PartialView(model);
        }
        
        public ActionResult ListRelated()
        {
            return View();
        }
    }
}