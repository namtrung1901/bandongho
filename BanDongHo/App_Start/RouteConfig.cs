using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BanDongHo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SanPhamAll",
                url: "tat-ca-san-pham",
                defaults: new { controller = "Sanpham", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Category",
               url: "san-pham/{slugcat}",
               defaults: new { controller = "Sanpham", action = "Category", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "PostAll",
               url: "bai-viet",
               defaults: new { controller = "Baiviet", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "PostTopic",
               url: "bai-viet/{slugtopic}",
               defaults: new { controller = "Baiviet", action = "PostTopic", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "PostDetail",
               url: "bai-viet/{slugtopic}/{slug}",
               defaults: new { controller = "Baiviet", action = "PostDetail", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "PostPages",
               url: "pages-{slug}",
               defaults: new { controller = "Baiviet", action = "PostPage", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Lienhe",
               url: "lien-he",
               defaults: new { controller = "Lienhe", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Dangnhap",
              url: "dang-nhap",
              defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Dangky",
              url: "dang-ky",
              defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Giohang",
              url: "gio-hang",
              defaults: new { controller = "Giohang", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
               name: "ChitietSP",
               url: "{slug}",
               defaults: new { controller = "Sanpham", action = "ProductDetail", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Trangchu", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
