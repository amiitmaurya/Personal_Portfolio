using Portfolio_MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio_MVC.Controllers
{
    // 🔹 Display Dashboard Page and load Page
    public class LandingPageController : Controller
    {
        // GET: LandingPage
        DatabaseContext db = new DatabaseContext();
        public ActionResult Dashboard()
        {
            // security check (optional but recommended)
            if (Session["UserEmail"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }



        // 🔹 Display Message and load Message Page
        public ActionResult Messages(int page = 1, int pageSize = 10)
        {
            if (Session["UserEmail"] == null)
                return RedirectToAction("Login", "Login");

            int totalRecords = db.Contact_mes.Count();

            var data = db.Contact_mes
                        .OrderByDescending(x => x.InsertDate)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return View(data);
        }

        // 🔹 Single Delete
        public ActionResult Delete(string email, int page, int pageSize)
        {
            if (Session["UserEmail"] == null)
                return RedirectToAction("Login", "Login");

            var data = db.Contact_mes.FirstOrDefault(x => x.Email == email);
            if (data != null)
            {
                db.Contact_mes.Remove(data);
                db.SaveChanges();
            }

            int totalRecords = db.Contact_mes.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // ✅ move to previous page if current page deleted
            if (page > totalPages && totalPages > 0)
                page = totalPages;

            if (totalPages == 0)
                page = 1;

            return RedirectToAction("Messages", new { page = page, pageSize = pageSize });
        }


        //🔹 Multi Delete

        [HttpPost]
        public ActionResult DeleteSelected(string[] selectedEmails, int pageSize, int page)
        {
            if (Session["UserEmail"] == null)
                return RedirectToAction("Login", "Login");

            if (selectedEmails != null && selectedEmails.Any())
            {
                var records = db.Contact_mes
                                .Where(x => selectedEmails.Contains(x.Email))
                                .ToList();

                db.Contact_mes.RemoveRange(records);
                db.SaveChanges();
            }

            // 🔹 Recalculate total records AFTER delete
            int totalRecords = db.Contact_mes.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);


            // 🔥 Always clamp page safely
            page = Math.Max(1, Math.Min(page, totalPages));
            return RedirectToAction("Messages", new { page = page, pageSize = pageSize });
        }


        public ActionResult ChngPsw()
        {
            // security check (optional but recommended)

            return View();
        }

    }
}
