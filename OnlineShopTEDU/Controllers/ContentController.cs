﻿using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopTEDU.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var model = new ContentDAO().ListAllPaging(page, pageSize);

            int totalRecord = 0;

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

        public ActionResult Detail(long id)
        {
            var model = new ContentDAO().GetByID(id);

            ViewBag.Tag = new ContentDAO().ListTag(id);

            return View(model);
        }

        public ActionResult Tag(string tagId, int page = 1, int pageSize = 10)
        {
            var model = new ContentDAO().ListAllByTag(tagId, page, pageSize);

            int totalRecord = 0;

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Tag = new ContentDAO().GetTag(tagId);


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
    }
}