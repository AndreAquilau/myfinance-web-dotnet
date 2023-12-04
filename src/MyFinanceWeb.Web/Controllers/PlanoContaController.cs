using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinanceWeb.Application.Interfaces;

namespace MyFinanceWeb.Web.Controllers;

[Route("PlanoConta")]
public class PlanoContaController : Controller
{
    private readonly IPlanoContaService _planoContaService;
    public PlanoContaController(IPlanoContaService planoContaService)
    {
        _planoContaService = planoContaService;
    }

    // GET: PlanoContaController
    [HttpGet()]
    public async Task<ActionResult> Index()
    {
        //return View();
        var planoContas = await _planoContaService.FindAll();

        return Ok(planoContas);
    }

    // GET: PlanoContaController/Details/5
    [HttpGet("Details/{id}")]
    public async Task<ActionResult> Details(int id)
    {
        var planoConta = await _planoContaService.FindById(id);
        //return View();

        return Ok(planoConta);
    }

    // GET: PlanoContaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PlanoContaController/Create
    [HttpPost()]
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
    [HttpPut(("Edit/{id}"))]
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

