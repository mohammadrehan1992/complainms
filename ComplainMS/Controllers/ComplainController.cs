using AutoMapper;
using ComplainMS.Models;
using ComplainMSDAL;
using ComplainMSDAL.CoreRepositories;
using ComplainMSModels;
using ComplainMSService;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ComplainMS.Extension.Helper;

namespace ComplainMS.Controllers
{
    public class ComplainController : Controller
    {
        IComplainService complainService = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ComplainController()
        {
            this.complainService = new ComplainService();
        }
        // GET: Complain
        public ActionResult Index()
        {
           List<ComplainListViewModels> result = complainService.GetComplains().
                Select(x => new ComplainListViewModels()
                {
                    ComplainId = x.ComplainId,
                    ComplainerId = x.ComplainerId.Value,
                    ComplainerEmail = x.Login?.Email,
                    Title = x.Title,
                    Description = x.Description,
                    Status= x.Status,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                }).ToList();

            return View(result);
        }

        // GET: Complain/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Complain/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Complain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddComplainViewModel addComplainViewModel)
        {
            string userEmail = Session["Email"] != null ? Session["Email"].ToString() : string.Empty;
            logger.Debug(string.Format("AddComplain [Title={0}, Description={1}, Complainer={2}]", addComplainViewModel.Title, addComplainViewModel.Description, userEmail));

            if (ModelState.IsValid)
            {
                try
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<AddComplainViewModel, Complain>());
                    var mapper = new Mapper(config);

                    addComplainViewModel.Status = STATUS.PENDING.ToString();
                    Complain complain = mapper.Map<Complain>(addComplainViewModel);
                    if (Session["LoginId"] !=null)
                    {
                        complain.ComplainerId = Convert.ToInt32(Session["LoginId"]);
                    }
                    
                    int isAdded = complainService.AddComplain(complain);

                    if (isAdded > 0)
                    {
                        return RedirectToAction("Index");
                        

                    }
                    else
                    {
                        ViewBag.Message = "Unable to perform this operation";
                        return View();
                    }

                }
                catch(Exception ex)
                {
                    logger.Error(ex);
                    ViewBag.Message = "Something went wrong Please check your internet connection";
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }

        // GET: Complain/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Complain/Edit/5
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

        // GET: Complain/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Complain/Delete/5
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
