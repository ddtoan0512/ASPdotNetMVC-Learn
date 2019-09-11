using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using OnlineShopTEDU.Common;

namespace OnlineShopTEDU.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ContentDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Create() {
            SetViewBag();
            return View();
        }

        public ActionResult Edit(long id)
        {
            var contentDAO = new ContentDAO();
            var content = contentDAO.GetByID(id);
            SetViewBag(content.CategoryID);


            return View(content);
        }

        [HttpPost]
        [ValidateInput(false)] // Do gui len ca html
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {

            }

            SetViewBag(model.CategoryID); 
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid) {
                var session = (UserLogin)Session[CommonConstants.USER_SESSION];
                model.CreatedBy = session.UserName;
                var culture = Session[CommonConstants.CurrentCulture];
                model.Language = culture.ToString();
                new ContentDAO().Create(model);
                return RedirectToAction("Index");

            }

            SetViewBag(); // Sau khi post ma khong modelstate.isvalid len thi no lai tra ve view nay va gan lai vao viewbag
            return View();
        }

        public void SetViewBag(long? selectedID = null)
        {
            var CategoryDAO = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(CategoryDAO.ListAll(), "ID", "Name",selectedID);
        }

    }
}