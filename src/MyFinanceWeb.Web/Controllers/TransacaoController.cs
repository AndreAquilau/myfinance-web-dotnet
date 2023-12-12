using Microsoft.AspNetCore.Mvc;
using MyFinanceWeb.Application.DTOs.PlanoContaDTOs;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;
using MyFinanceWeb.Application.Interfaces;

namespace MyFinanceWeb.Web.Controllers;

[Route("Transacao")]
public class TransacaoController : Controller
{
    private readonly IPlanoContaService _planoContaService;
    private readonly ITransacaoService _transacaoService;

    public TransacaoController(ITransacaoService transacaoService, IPlanoContaService planoContaService)
    {
        _transacaoService = transacaoService;
        _planoContaService = planoContaService;
    }

    // GET: TransacaoController
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var transacoes = await _transacaoService.FindAll();
        return View(transacoes);
    }

    // GET: TransacaoController/Details/{id}
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
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Historico, Valor, Data, PlanoContaId")] TransacaoDTO transacaoDTO)
    {
        try
        {
            // Verifica se o modelo está de acordo com TransacaoDTO
            if (string.IsNullOrWhiteSpace(transacaoDTO.Historico) || transacaoDTO.Valor <= 0 || transacaoDTO.Data == default)
            {
                // Busca lista de Plano de Contas
                IEnumerable<PlanoContaDTO> listPlanoConta = await _planoContaService.FindAll();
                transacaoDTO.ListPlanoConta = listPlanoConta;

                return View(transacaoDTO);
            }
            
            // Chama o serviço para criar a transação
            var transacao = await _transacaoService.Create(transacaoDTO);

            // Verifica se a transação foi criada com sucesso
            if (transacao != null)
                return RedirectToAction("Details", new { id = transacao.Id });
            else
            {
                // Se houve um problema ao criar a transação, retorne para a view de criação com uma mensagem de erro
                ModelState.AddModelError(string.Empty, "Erro ao criar a transação.");
                return View();
            }
        
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    // -------------------------------------------------------------
    
    // PUT: TransacaoController/Edit/{id}
    [HttpGet]
    [Route("/Edit/{id}")]
    // [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id)
    {
        var transacao = await _transacaoService.FindById(id);
        return View(transacao);
    }

    // PUT: TransacaoController/Edit/{id}
    [HttpPost]
    [Route("/Edit/{id}")]
    // [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Historico, Valor, Data, PlanoContaId")] TransacaoDTO transacaoDTO)
    {
        try
        {
            if (id != transacaoDTO.Id)
                return BadRequest();

            // Chama o serviço para criar a transação
            var transacao = await _transacaoService.Update(transacaoDTO);

            // Verifica se a transação foi criada com sucesso
            if (transacao != null)
                return RedirectToAction("Details", new { id = transacao.Id });
            else
            {
                // Se houve um problema ao criar a transação, retorne para a view de criação com uma mensagem de erro
                ModelState.AddModelError(string.Empty, "Erro ao editar a transação.");
                return View();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    // -------------------------------------------------------------

    // DELETE: TransacaoController/Delete/{id}
    [HttpGet]
    [Route("/Delete/{id}")]
    // [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var transacao = await _transacaoService.FindById(id);
        return View(transacao);
    }

    // DELETE: TransacaoController/Delete/{id}
    [HttpPost]
    [Route("/Delete/{id}")]
    // [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int id, [Bind("Id")] TransacaoDTO transacaoDTO)
    {
        try
        {
            if (id != transacaoDTO.Id)
                return BadRequest();

            var transacao = await _transacaoService.FindById(transacaoDTO.Id);

            if (transacao == null)
                return NotFound();

            await _transacaoService.Delete(transacao.Id);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Erro interno do servidor");
        }
    }
}

