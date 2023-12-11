using Microsoft.AspNetCore.Mvc;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;
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
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var transacoes = await _transacaoService.FindAll();
        return View(transacoes);
    }

    // GET: TransacaoController/Details/5
    [HttpGet]
    [Route("/Details/{id}")]
    public async Task<ActionResult> Details(int id)
    {

        var transacao = await _transacaoService.FindById(id);
        return View(transacao);
    }

    // POST: TransacaoController/Create
    [HttpPost]
    [Route("/Create")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Historico", "Valor", "Data")] TransacaoDTO transacaoDTO)
    {
        try
        {
            // Verifica se o modelo está de acordo com TransacaoDTO
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Chama o serviço para criar a transação
            var transacao = await _transacaoService.Create(transacaoDTO);

            // Retorna uma resposta de sucesso com a transação criada
            return View(transacao);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    // PUT: TransacaoController/Edit/5
    [HttpPut]
    [Route("/Edit/{id}")]
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

    // DELETE: TransacaoController/Delete/5
    [HttpDelete]
    [Route("/Delete/{id}")]
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

