using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace OnlineShopTEDU.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
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


            return View();
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
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid) {

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