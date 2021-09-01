using CryptoManager.Models;
using CryptoManager.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoManager.WebMVC.Controllers
{
    [Authorize]
    public class InvestmentController : Controller
    {
        // GET: Investment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InvestmentService(userId);
            var model = service.GetInvestments();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvestmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateInvestmentService();
            if (service.CreateInvestment(model))
            {
                TempData["SaveResult"] = "Investment Successful";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Investment could not be processed");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateInvestmentService();
            var model = svc.GetInvestmentById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateInvestmentService();
            var detail = service.GetInvestmentById(id);
            var model =
                new InvestmentEdit
                {
                    InvestmentId = detail.InvestmentId,
                    Amount = detail.Amount,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InvestmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.InvestmentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateInvestmentService();
            if (service.UpdateInvestment(model))
            {
                TempData["SaveResult"] = "Your investment was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your investment could not be processed");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateInvestmentService();
            var model = svc.GetInvestmentById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateInvestmentService();
            service.DeleteInvestment(id);
            TempData["SaveResult"] = "Your investment is deleted";
            return RedirectToAction("Index");
        }
        private InvestmentService CreateInvestmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InvestmentService(userId);
            return service;
        }
    }
}