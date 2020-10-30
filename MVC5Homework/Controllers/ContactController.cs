using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Homework.Models;
using Omu.ValueInjecter;

namespace MVC5Homework.Controllers
{
    public class ContactController : Controller
    {
        private CustomerEntities db = new CustomerEntities();

        // GET: Contact
        public ActionResult Index()
        {
            return View(db.客戶聯絡人);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶聯絡人 data)
        {
            if (ModelState.IsValid)
            {
                db.客戶聯絡人.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = db.客戶聯絡人.Find(id);
            if (data == null)
            {
                return this.HttpNotFound();
            };
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, 客戶聯絡人 data)
        {
            if (ModelState.IsValid)
            {
                var c = db.客戶聯絡人.Create();
                c.InjectFrom(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = db.客戶聯絡人.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            };
            return View(data);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            var item = db.客戶聯絡人.Find(id);
            if (item == null) return HttpNotFound();

            db.客戶聯絡人.Remove(item);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}