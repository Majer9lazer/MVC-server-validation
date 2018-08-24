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
        private  ServerValidation_DbEntities db = new ServerValidation_DbEntities();

        public  CallingCouriersController()
        {
            try
            {
                if (!db.Countries.Any(f => f.CountryName.Contains("Казахстан")) || !db.Cities.Any(f =>
                        f.CityName.Contains("Алматы")))
                {
                    db.Countries.Add(new Country() { CountryName = "Казахстан" });
                    db.SaveChanges();
                    db.Cities.Add(new City()
                    {
                        CityName = "Алматы",
                        CountryId = db.Countries.FirstOrDefault(f => f.CountryName.Contains("Казахстан")).CountryId
                    });
                    db.SaveChanges();
                }

                if (!db.Cities.Any(a => a.CityName.Contains("Астана")))
                {
                    db.Cities.Add(new City()
                    {
                        CityName = "Астана",
                        CountryId = db.Countries.FirstOrDefault(f => f.CountryName.Contains("Казахстан")).CountryId
                    });
                    db.SaveChanges();
                }
                 if (!db.FormOfPayments.Any(f =>
                    f.Name.Contains("Наличные") || f.Name.Contains("Безналичные") || f.Name.Contains("Договор")))
                {
                    db.FormOfPayments.AddRange(new[]
                    {
                    new FormOfPayment() { Name = "Наличные" },
                    new FormOfPayment() { Name = "Безналичные" },
                    new FormOfPayment() { Name = "Договор" }
                });
                    db.SaveChanges();
                }
                 if (!db.DepartureTypes.Any(a => a.DepartureTypeName.Contains("Документы")
                && a.DepartureTypeName.Contains("Посылка") && a.DepartureTypeName.Contains("Термогруз")))
                {
                    db.DepartureTypes.AddRange(new[]
                    {
                        new DepartureType(){DepartureTypeName = "Документы"},
                        new DepartureType(){DepartureTypeName = "Посылка"},
                        new DepartureType(){DepartureTypeName = "Термогруз"},
                    });
                    db.SaveChanges();
                }
                 if (!db.TariffsViews.Any(a => a.TariffsViewName.Contains("Экспресс") && a.TariffsViewName.Contains("Эконом")))
                {
                    db.TariffsViews.AddRange(new[]
                    {
                        new TariffsView() { TariffsViewName = "Экспресс" },
                        new TariffsView() { TariffsViewName = "Эконом" }
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }
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
