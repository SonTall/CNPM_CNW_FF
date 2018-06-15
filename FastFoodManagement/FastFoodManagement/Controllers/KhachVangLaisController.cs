using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FastFoodManagement.Models;

namespace FastFoodManagement.Controllers
{
    public class KhachVangLaisController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        // GET: KhachVangLais
        public ActionResult Index()
        {
            return View(db.KhachVangLais.ToList());
        }

        // GET: KhachVangLais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachVangLai khachVangLai = db.KhachVangLais.Find(id);
            if (khachVangLai == null)
            {
                return HttpNotFound();
            }
            return View(khachVangLai);
        }

        // GET: KhachVangLais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachVangLais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhachVangLai,HoTen,DiaChi,SoDienThoai")] KhachVangLai khachVangLai)
        {
            if (ModelState.IsValid)
            {
                db.KhachVangLais.Add(khachVangLai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachVangLai);
        }

        // GET: KhachVangLais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachVangLai khachVangLai = db.KhachVangLais.Find(id);
            if (khachVangLai == null)
            {
                return HttpNotFound();
            }
            return View(khachVangLai);
        }

        // POST: KhachVangLais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhachVangLai,HoTen,DiaChi,SoDienThoai")] KhachVangLai khachVangLai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachVangLai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachVangLai);
        }

        // GET: KhachVangLais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachVangLai khachVangLai = db.KhachVangLais.Find(id);
            if (khachVangLai == null)
            {
                return HttpNotFound();
            }
            return View(khachVangLai);
        }

        // POST: KhachVangLais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachVangLai khachVangLai = db.KhachVangLais.Find(id);
            db.KhachVangLais.Remove(khachVangLai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
