using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanDongHo.Models;
namespace BanDongHo.Controllers
{
    public class BaivietController : Controller
    {
        BanDongHoDBContext db = new BanDongHoDBContext();
        // GET: Baiviet
        public ActionResult Index()
        {
            var lstTopic = db.Topics.Where(m => m.Status == 1 && m.ParentId == 0).ToList();
            var Topic = db.Topics.Where(m => m.Status == 1).ToList();
            ViewBag.ListTopic = Topic;
            var lstPost = db.Posts.Where(m => m.Status == 1).ToList();
            ViewBag.ListPost = lstPost;
            return View(lstTopic);
        }
        public ActionResult PostTopic(String slugtopic)
        {
            var lstTopic = db.Topics.Where(m => m.Status == 1 && m.Slug == slugtopic).ToList();
            var lstPost = db.Posts.Where(m => m.Status == 1).ToList();
            ViewBag.ListPost = lstPost;
            return View(lstTopic);
        }
        public ActionResult PostDetail(String slugtopic, String slug)
        {
            var lstTopic = db.Topics.Where(m => m.Status == 1 && m.Slug == slugtopic).ToList();
            var lstPost = db.Posts.Where(m => m.Status == 1 && m.Slug == slug).ToList();
            return View(lstPost);
        }
        public ActionResult PostPage(String slug)
        {
            return View();
        }
    }
}