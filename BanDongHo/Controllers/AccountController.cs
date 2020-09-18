using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Lib;
using BanDongHo.Models;

namespace BanDongHo.Controllers
{
    public class AccountController : Controller
    {
        BanDongHoDBContext db = new BanDongHoDBContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Trangchu");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            Encryptor mahoa = new Encryptor();
            string username = collection["UserName"];
            string password = mahoa.MD5Hash(collection["Pass"]);
            ViewBag.Message = "";
            User user = db.Users.SingleOrDefault(m => m.UserName == username && m.Password == password);
            if(user != null)
            {
                Session["UserName"] = user;
                return RedirectToAction("Index", "Trangchu");
            }
            else
            {
                ViewBag.Message = "Tài khoản hoặc mật khẩu không chính xác";
            }
            return View();
        }

        public ActionResult SaveRegister()
        {
            Encryptor mahoa = new Encryptor();
            User muser = new User();
            muser.FullName = Request.Form["FullName"];
            muser.Email = Request.Form["Email"];
            muser.UserName = Request.Form["UserName"];
            muser.Password = mahoa.MD5Hash(Request["Pass"]);
            muser.Phone = Request.Form["Phone"];
            muser.Img = "";
            muser.Gender = 9;
            muser.Created_at = DateTime.Now;
            muser.Created_by = 1;
            muser.Updated_at = DateTime.Now;
            muser.Updated_by = 1;
            muser.Access = 2;
            muser.Status = 1;
            db.Users.Add(muser);
            db.SaveChanges();
            return RedirectToAction("Index", "Trangchu");
        }
    }
}