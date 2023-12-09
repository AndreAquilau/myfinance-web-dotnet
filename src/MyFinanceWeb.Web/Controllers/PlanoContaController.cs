using Microsoft.AspNetCore.Mvc;
using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using MyFinanceWeb.Application.Interfaces;

namespace MyFinanceWeb.Web.Controllers;

[Route("PlanoConta")]
public class PlanoContaController : Controller
{
    private readonly IPlanoContaService _planoContaService;
    private readonly ILogger<PlanoContaController> _logger;
    public PlanoContaController(IPlanoContaService planoContaService, ILogger<PlanoContaController> logger)
    {
        _planoContaService = planoContaService;
        _logger = logger;
    }

    // GET: PlanoContaController
    [HttpGet()]
    public async Task<ActionResult> Index()
    {
        var planoContas = await _planoContaService.FindAll();

        return View(planoContas);
    }

    // GET: PlanoContaController/Details/5
    [HttpGet("Details/{id}")]
    public async Task<ActionResult> Details(int id)
    {
        var planoConta = await _planoContaService.FindById(id);

        if (planoConta == null)
            return NotFound();

        ViewBag.Tipos = new List<string> { "R", "D" };
        return View(planoConta);
    }

    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public async Task<ActionResult> Cadastro(int id)
    {
        if (id == 0)
            return View();

        var planoConta = await _planoContaService.FindById(id);

        if (planoConta == null)
            return NotFound();

        return View(planoConta);
    }

    [HttpPost]
    [Route("Cadastro")]
    [Route("Cadastro/{id?}")]
    public async Task<ActionResult> Cadastro(PlanoContaDTO planoContaDTO)
    {

        if (planoContaDTO.Id == 0)
            await _planoContaService.Create(planoContaDTO);
        else
            await _planoContaService.Update(planoContaDTO);

        return RedirectToAction(nameof(Index));
    }

    // GET: PlanoContaController/Create
    [HttpGet("Create")]
    public ActionResult Create()
    {
        ViewBag.Tipos = new List<string> { "R", "D" };
        return View();
    }

    // POST: PlanoContaController/Create
    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Tipo,Descricao")] PlanoContaDTO planoContaDTO)
    {
        try
        {
            if (!ModelState.IsValid)
                return View();

            await _planoContaService.Create(planoContaDTO);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar plano de conta", ex);
            return View();
        }
    }

    // GET: PlanoContaController/Edit/5 
    [HttpGet("Edit/{id}")]
    public async Task<ActionResult> Edit(int id)
    {
        var planoConta = await _planoContaService.FindById(id);

        if (planoConta == null)
            return NotFound();

        return View(planoConta);
    }

    // POST: PlanoContaController/Edit/5
    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id,Tipo,Descricao")] PlanoContaDTO planoContaDTO)
    {
        try
        {
            if (!ModelState.IsValid)
                return View();

            await _planoContaService.Update(planoContaDTO);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError("Erro ao editar Plano de Conta", ex);
            return View();
        }
    }

    // GET: PlanoContaController/Delete/5
    [HttpGet("Delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var planoConta = await _planoContaService.FindById(id);

        if (planoConta == null)
            return NotFound();

        return View(planoConta);
    }

    // POST: PlanoContaController/Delete/5
    [HttpPost("Delete/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, [Bind("Id,Tipo,Descricao")] PlanoContaDTO planoContaDTO)
    {
        try
        {
            var planoConta = await _planoContaService.FindById(id);

            if (planoConta == null)
                return NotFound();

            await _planoContaService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError("Erro ao deletar Plano de Conta", ex);
            return View();
        }
    }
}

