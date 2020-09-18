using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanDongHo.Controllers
{
    public class BaivietController : Controller
    {
        // GET: Baiviet
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PostTopic(String slugtopic)
        {
            return View();
        }
        public ActionResult PostDetail(String slugtopic, String slug)
        {
            return View();
        }
        public ActionResult PostPage(String slug)
        {
            return View();
        }
    }
}