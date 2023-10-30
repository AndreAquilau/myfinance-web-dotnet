using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinanceWeb.Services;

namespace MyFinanceWeb.Controllers;

public class PlanoConta : Controller
{
    private readonly ILogger<PlanoConta> _logger;
    private readonly IPlanoContaService _planoContaService;

    public PlanoConta(ILogger<PlanoConta> logger, IPlanoContaService planoContaService)
    {
        _logger = logger;
        _planoContaService = planoContaService;
    }

    // GET: PlanoContas
    public ActionResult Index()
    {
        var planoContas = _planoContaService.ListarPlanoContas();
        return View();
    }

    // GET: PlanoContas/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: PlanoContas/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PlanoContas/Create
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

    // GET: PlanoContas/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: PlanoContas/Edit/5
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

    // GET: PlanoContas/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: PlanoContas/Delete/5
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

