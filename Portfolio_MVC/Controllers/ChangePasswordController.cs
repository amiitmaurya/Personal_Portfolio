using Portfolio_MVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio_MVC.Controllers
{
    public class ChangePasswordController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Change_Password
        public ActionResult ChangePassword()
        {

            if (Session["UserEmail"] == null)
            {

                return RedirectToAction("Login", "Login");

            }

            var model = new ChangePasswordViewModel
            {
                Email = Session["UserEmail"].ToString()   // ⭐ AUTO FETCH
            };

            return View("ChangePassword", model);


            //return View(new ChangePasswordViewModel());
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View("ChangePassword", model);

            if (Session["UserEmail"] == null)
            {
                TempData["Error"] = "Session expired. Please login again";
                return RedirectToAction("Login", "Login");

            }



            string Email = (Session["UserEmail"].ToString());

            // ✅ SAME TABLE AS SIGNUP
            var user = db.Regs.FirstOrDefault(u => u.Email == Email);

            if (user == null)
            {
                TempData["Error"] = "User not found";
                return View("ChangePassword", model);
            }

            // Old password check
            if (user.Password != model.OldPassword)
            {
                ModelState.AddModelError("OldPassword", "Old password is incorrect"); // ⭐ HIGHLIGHT
                return View("ChangePassword", model);                                  // ⭐ HIGHLIGHT
            }
            // 🔴 5️⃣ NEW & CONFIRM PASSWORD CHECK (POPUP)
            if (model.NewPassword != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "New password and confirm password do not match"); // ⭐
                return View("ChangePassword", model);                                                          // ⭐
            }

            // ❌ Old & New same check (extra safety)
            if (model.OldPassword == model.NewPassword)
            {
                // ModelState.AddModelError("NewPassword", "New password must be different");
                // return View("ChangePassword", model);
                TempData["Error"] = "New password must be different from old password";
                return RedirectToAction("ChangePassword");
            }

            // Update password
            user.Password = model.NewPassword;
            db.SaveChanges();

            TempData["Success"] = "Password changed successfully";
            return RedirectToAction("Dashboard", "LandingPage");
        }

    }
}
