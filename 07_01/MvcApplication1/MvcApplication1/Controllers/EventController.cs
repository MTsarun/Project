using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using WebMatrix.WebData;

using MvcApplication1.Filters;


namespace MvcApplication1.Controllers
{
    
     [Authorize]
     [InitializeSimpleMembership]
    public class EventController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Event/
            

        public ActionResult Index()
        {
            User user = db.Users.Find(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.user = user;

            return View(db.Receptions.ToList());
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id = 0)
        {
            Reception reception = db.Receptions.Find(id);
            if (reception == null)
            {
                return HttpNotFound();
            }
            return View(reception);
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Event/Create

        [HttpPost]
        public ActionResult Create(Reception reception)
        {
            if (ModelState.IsValid)
            {
                db.Receptions.Add(reception);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reception);
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reception reception = db.Receptions.Find(id);
            if (reception == null)
            {
                return HttpNotFound();
            }
            return View(reception);
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        public ActionResult Edit(Reception reception)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reception).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reception);
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reception reception = db.Receptions.Find(id);
            if (reception == null)
            {
                return HttpNotFound();
            }
            return View(reception);
        }

        //
        // POST: /Event/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Reception reception = db.Receptions.Find(id);
            db.Receptions.Remove(reception);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}