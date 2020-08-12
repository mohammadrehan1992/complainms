using ComplainMS.Models;
using ComplainMSCommon;
using ComplainMSDAL;
using ComplainMSDAL.CoreRepositories;
using ComplainMSService;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComplainMS.Controllers
{
    public class UserController : Controller
    {
        ILoginService loginService = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public UserController()
        {
            this.loginService = new LoginService();
        }

        public ActionResult Index()
        {
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel ,string returnUrl)
        {
            logger.Debug(string.Format("Login [Email={0}, Password={1}]", loginViewModel.Email, loginViewModel.Password));
            if (ModelState.IsValid)
            {
                
                try
                {
                    string password = SecurityLayer.GetMd5Hash(loginViewModel.Password).ToUpper();
                    var user = loginService. GetLogin(loginViewModel.Email, password);

                    logger.Debug(string.Format("Login RESPONSE [{0}]", JsonConvert.SerializeObject(user)));

                    if (user != null)
                    {
                        Session["LoginId"] = user.LoginId;
                        Session["Email"] = user.Email;
                        //return RedirectToLocal(returnUrl);
                        return RedirectToAction("Index","Complain");
                    }
                    else
                    {
                        ViewBag.Message = "Wrong email or password";
                        return View();
                    }

                }
                catch(Exception ex)
                {
                    ViewBag.Message = "Something went wrong,Please check your internet connection";
                    logger.Error(ex);
                    return View();
                }

            }
            else
            {
                return View();
            }
            
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
