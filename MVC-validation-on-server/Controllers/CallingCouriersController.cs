using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_validation_on_server.Models;

namespace MVC_validation_on_server.Controllers
{
    public class CallingCouriersController : Controller
    {
        private ServerValidation_DbEntities db = new ServerValidation_DbEntities();

        // GET: CallingCouriers
        public async Task<ActionResult> Index()
        {
            var callingCouriers = db.CallingCouriers.Include(c => c.FormOfPayment).Include(c => c.City).Include(c => c.Country).Include(c => c.DepartureType).Include(c => c.TariffsView);
            return View(await callingCouriers.ToListAsync());
        }

        // GET: CallingCouriers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallingCourier callingCourier = await db.CallingCouriers.FindAsync(id);
            if (callingCourier == null)
            {
                return HttpNotFound();
            }
            return View(callingCourier);
        }

        // GET: CallingCouriers/Create
        public ActionResult Create()
        {
            ViewBag.FormOfPaymentId = new SelectList(db.FormOfPayments, "FormOfPaymentId", "Name");
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.DepartureTypeId = new SelectList(db.DepartureTypes, "DepartureTypeId", "DepartureTypeName");
            ViewBag.TariffsViewId = new SelectList(db.TariffsViews, "TariffsViewId", "TariffsViewName");
            return View();
        }

        // POST: CallingCouriers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CallingCourierId,BIN_IIN,ContactPerson,SendersAddress,Email,DesirableDate,WhenPickUpShipment,FormOfPaymentId,CountryId,CityId,DepartureTypeId,TariffsViewId,Weight")] CallingCourier callingCourier)
        {
            if (ModelState.IsValid)
            {
                db.CallingCouriers.Add(callingCourier);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FormOfPaymentId = new SelectList(db.FormOfPayments, "FormOfPaymentId", "Name", callingCourier.FormOfPaymentId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", callingCourier.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", callingCourier.CountryId);
            ViewBag.DepartureTypeId = new SelectList(db.DepartureTypes, "DepartureTypeId", "DepartureTypeName", callingCourier.DepartureTypeId);
            ViewBag.TariffsViewId = new SelectList(db.TariffsViews, "TariffsViewId", "TariffsViewName", callingCourier.TariffsViewId);
            return View(callingCourier);
        }

        // GET: CallingCouriers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallingCourier callingCourier = await db.CallingCouriers.FindAsync(id);
            if (callingCourier == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormOfPaymentId = new SelectList(db.FormOfPayments, "FormOfPaymentId", "Name", callingCourier.FormOfPaymentId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", callingCourier.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", callingCourier.CountryId);
            ViewBag.DepartureTypeId = new SelectList(db.DepartureTypes, "DepartureTypeId", "DepartureTypeName", callingCourier.DepartureTypeId);
            ViewBag.TariffsViewId = new SelectList(db.TariffsViews, "TariffsViewId", "TariffsViewName", callingCourier.TariffsViewId);
            return View(callingCourier);
        }

        // POST: CallingCouriers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CallingCourierId,BIN_IIN,ContactPerson,SendersAddress,Email,DesirableDate,WhenPickUpShipment,FormOfPaymentId,CountryId,CityId,DepartureTypeId,TariffsViewId,Weight")] CallingCourier callingCourier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(callingCourier).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FormOfPaymentId = new SelectList(db.FormOfPayments, "FormOfPaymentId", "Name", callingCourier.FormOfPaymentId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", callingCourier.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", callingCourier.CountryId);
            ViewBag.DepartureTypeId = new SelectList(db.DepartureTypes, "DepartureTypeId", "DepartureTypeName", callingCourier.DepartureTypeId);
            ViewBag.TariffsViewId = new SelectList(db.TariffsViews, "TariffsViewId", "TariffsViewName", callingCourier.TariffsViewId);
            return View(callingCourier);
        }

        // GET: CallingCouriers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallingCourier callingCourier = await db.CallingCouriers.FindAsync(id);
            if (callingCourier == null)
            {
                return HttpNotFound();
            }
            return View(callingCourier);
        }

        // POST: CallingCouriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CallingCourier callingCourier = await db.CallingCouriers.FindAsync(id);
            db.CallingCouriers.Remove(callingCourier);
            await db.SaveChangesAsync();
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
