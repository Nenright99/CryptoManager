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
    public class CryptoController : Controller
    {
        public ActionResult Index()
        {
            var service = new CryptoService();
            var model = service.GetCryptos();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CryptoCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateCryptoService();
            if (service.CreateCrypto(model))
            {
                TempData["SaveResult"] = "Crypto Successful";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Crypto could not be processed");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateCryptoService();
            var model = svc.GetCryptoById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateCryptoService();
            var detail = service.GetCryptoById(id);
            var model =
                new CryptoEdit
                {
                    CryptoId = detail.CryptoId,
                    Name = detail.Name,
                    Ticker = detail.Ticker
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CryptoEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.CryptoId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCryptoService();
            if (service.UpdateCrypto(model))
            {
                TempData["SaveResult"] = "Your Crypto was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Crypto could not be processed");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCryptoService();
            var model = svc.GetCryptoById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCryptoService();
            service.DeleteCrypto(id);
            TempData["SaveResult"] = "Your Crypto is deleted";
            return RedirectToAction("Index");
        }
        private CryptoService CreateCryptoService()
        {
            var service = new CryptoService();
            return service;
        }
    }
}