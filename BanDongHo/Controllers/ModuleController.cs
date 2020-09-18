using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;

namespace BanDongHo.Controllers
{
    public class ModuleController : Controller
    {
        BanDongHoDBContext db = new BanDongHoDBContext();
        // GET: Module
        public PartialViewResult MainMenu()
        {
            var model = db.Menus.Where(m => m.Status == 1 && m.ParentId == 0).OrderBy(m => m.Orders).ToList();
            return PartialView("_MainMenu", model);
        }

        public PartialViewResult ChildMainMenu(int id)
        {
            int dem = db.Menus.Where(m => m.Status == 1 && m.ParentId == id).Count();
            if (dem != 0)
            {
                var model = db.Menus.Where(m => m.Status == 1 && m.ParentId == id).OrderBy(m => m.Orders).ToList();
                return PartialView("_ChildMainMenu", model);
            }
            return null;
        }

        public PartialViewResult Slider()
        {
            var model = db.Sliders.Where(s => s.Status == 1 && s.Position == "slideshow").ToList();
            return PartialView("_Sliders", model);
        }
        public PartialViewResult Brand()
        {
            var model = db.Categorys.Where(c => c.Status == 1 && c.ParentId == 0).OrderBy(c => c.Orders).ToList();
            return PartialView("_Brand", model);
        }
        public PartialViewResult ListCategory()
        {
            var model = db.Categorys.Where(c => c.Status == 1 && c.ParentId == 0).OrderBy(c => c.Orders).ToList();
            return PartialView("_ListCategory", model);
        }

        public PartialViewResult ChildListCategory(int id)
        {
            int dem = db.Categorys.Where(l => l.ParentId == id && l.Status == 1).Count();
            if (dem != 0)
            {
                var model = db.Categorys.Where(c => c.Status == 1 && c.ParentId == id).OrderBy(c => c.Orders).ToList();
                return PartialView("_ChildListCategory", model);
            }
            return null;
        }

    }
}