using Portfolio_MVC.Models;
using System;
using System.Web.Mvc;

namespace Portfolio_MVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View(new Contact_me());
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactInsert(Contact_me model)
        {
            if (ModelState.IsValid)
            {
                model.InsertDate = DateTime.Now;
                db.Contact_mes.Add(model);
                db.SaveChanges();

                TempData["Success"] = "Message sent successfully!";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Please fill all the details!";
            return View("Index");
        }
    }
}