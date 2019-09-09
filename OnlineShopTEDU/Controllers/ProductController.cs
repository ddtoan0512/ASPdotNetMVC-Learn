using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace OnlineShopTEDU.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ListAll();
            return PartialView(model);
        }


        public ActionResult Category(long cateID, int page = 1, int pageSize = 2)
        {
            var category = new CategoryDAO().ViewDetail(cateID);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDAO().ListByCategoryId(cateID, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
 
            return View(model);
        }

        [OutputCache(CacheProfile = "Cache1ForProduct")]
        public ActionResult Detail(long id)
        {
            var product = new ProductDAO().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDAO().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProducts = new ProductDAO().ListRelatedProducts(id);
            return View(product);
        }
    }
}