using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;

namespace BanDongHo.Controllers
{
    public class LienheController : Controller
    {
        BanDongHoDBContext db = new BanDongHoDBContext();
        // GET: Lienhe
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveContact()
        {
            Contact lh = new Contact();
            lh.FullName = Request.Form["FullName"];
            lh.Email = Request.Form["Email"];
            lh.Phone = Request.Form["Phone"];
            lh.Title = Request.Form["Title"];
            lh.Detail = Request.Form["Detail"];
            lh.Created_at = DateTime.Now;
            lh.Created_by = 1;
            lh.Updated_at = DateTime.Now;
            lh.Updated_by = 1;
            lh.Status = 0;
            db.Contacts.Add(lh);
            db.SaveChanges();
            return RedirectToAction("Index", "Lienhe");
        }
    }
}