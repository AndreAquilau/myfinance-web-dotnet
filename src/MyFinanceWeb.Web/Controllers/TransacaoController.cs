using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFinanceWeb.Web.Controllers
{
    public class TransacaoController : Controller
    {
        // GET: TransacaoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TransacaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransacaoController/Create
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

        // GET: TransacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransacaoController/Edit/5
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

        // GET: TransacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransacaoController/Delete/5
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
