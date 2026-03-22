using Portfolio_MVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DatabaseContext db = new DatabaseContext();
        public ActionResult Login()
        {
            return View(new LoginSignupViewModel
            {
                Login = new LoginViewModel(),
                Signup = new SignupViewModel()
            });
        }
        // ================= Login =================
        [HttpPost]
        public ActionResult Login(LoginSignupViewModel model)
        {
            ModelState.Remove("Signup.Name");
            ModelState.Remove("Signup.Email");
            ModelState.Remove("Signup.Password");

            if (ModelState.IsValid)
            {
                var user = db.Regs
                             .Where(x => x.Email == model.Login.Email
                                      && x.Password == model.Login.Password)
                             .FirstOrDefault();

                if (user != null)
                {
                    Session["UserEmail"] = user.Email;

                    return RedirectToAction("Dashboard", "LandingPage");
                }
                else
                {
                    ViewBag.Error = "Invalid Email or Password";
                }
            }
            return View(model);
        }

        // ================= SIGNUP =================


        public ActionResult Signup()
        {
            return RedirectToAction("Login");
        }

        // POST: Signup
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Signup(LoginSignupViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Login", model);
        //    }

        //    // Check if email already exists
        //    bool exists = db.Regs.Any(x => x.Email == model.Signup.Email);

        //    if (exists)
        //    {
        //        ModelState.AddModelError("Signup.Email", "Email already registered");
        //        return View("Login", model);
        //    }

        //    Reg reg = new Reg
        //    {
        //        Name = model.Signup.Name,
        //        Email = model.Signup.Email,
        //        Password = model.Signup.Password
        //    };

        //    //db.Regs.Add(reg);
        //    db.Regs.Add(new Reg
        //    {
        //        Name = model.Signup.Name,
        //        Email = model.Signup.Email,
        //        Password = model.Signup.Password
        //    });
        //    db.SaveChanges();

        //    TempData["Success"] = "Registration successful. Please login.";
        //    return RedirectToAction("Login");

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(LoginSignupViewModel model)
        {
            ModelState.Clear();
            TempData["Error"] = "New user registration is currently disabled.";
            return RedirectToAction("Login");
        }






        // ================= LOGOUT =================
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login", "Login");



        }
    }
}