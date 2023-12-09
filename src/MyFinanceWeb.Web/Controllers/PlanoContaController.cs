using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinanceWeb.Application.Interfaces;

namespace MyFinanceWeb.Web.Controllers;

[Route("PlanoConta")]
public class PlanoContaController : Controller
{
    public class PlanoContaController : Controller
    {
        public PlanoContaController(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }


        protected readonly IPlanoContaService _planoContaService;

        // GET: PlanoContaController
        public ActionResult Index()
        {
            var pc = _planoContaService.FindAll();
            pc.Wait();

            var planoContas = pc.Result;

            return View();
        }

        // GET: PlanoContaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlanoContaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanoContaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlanoContaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanoContaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlanoContaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanoContaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
