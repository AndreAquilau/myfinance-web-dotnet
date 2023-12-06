using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinanceWeb.Application.Interfaces;

namespace MyFinanceWeb.Web.Controllers;

[Route("Transacao")]
public class TransacaoController : Controller
{
    private readonly ITransacaoService _transacaoService;
    public TransacaoController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }

    // GET: TransacaoController
    [HttpGet()]
    public async Task<ActionResult> Index()
    {
        //return View();
        var transacoes = await _transacaoService.FindAll();

        return View(transacoes);
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

