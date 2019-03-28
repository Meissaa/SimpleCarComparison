using AutoMapper;
using CarComparison.Common.Exceptions;
using CarComparison.Common.Data;
using CarComparison.Common.Managers;
using CarComparison.WebApp.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarComparison.WebApp.Controllers
{
    public class CarComparisonController : Controller
    {

        private static ILog _log;
        private ICarVerifierManger _verifierManager;

        public CarComparisonController(ICarVerifierManger verifierManager) {

            _log = LogManager.GetLogger(this.GetType().FullName);
            _verifierManager = verifierManager;
        }

        public ActionResult Index()
        {
            try
            {
                _log.Info("begin Index");
                var carsList = _verifierManager.GetCarNames();

                ViewBag.CarNames = new SelectList(carsList);

                return View();
            }
            catch (Exception ex) {

                _log.Error(ex);
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }

        public ActionResult VerifyCars(IList<CarModel> listCars) {

            _log.Info("begin VerifyCars");

            if (ModelState.IsValid)
            {
                try
                {
                    _log.Info("Invoking Verify on CarVerifierManger instance");
                    IList<Car> cars = _verifierManager.Verify(Mapper.Map<IList<Car>>(listCars));

                    return View("VerifyCars", Mapper.Map<IList<CarModel>>(cars));

                }
                catch (VerifierException ex) {

                    _log.Error(ex);
                    TempData["Error"] = ex.Message;
                    return View("Error");
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                    TempData["Error"] = ex.Message;
                    return View("Error");
                }
            }

            return View("Index");
        }
    }
}