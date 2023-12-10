using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinanceWeb.Application.Interfaces;

namespace MyFinanceWeb.Web.Controllers;

public class DashboardController : Controller
{
    private readonly IUtilService _utilService;
    public DashboardController(IUtilService utilService)
    {
        _utilService = utilService;
    }

    // GET: DashboardController
    public ActionResult Index()
    {
        return View();
    }

    // GET: DashboardController
    [HttpGet("MovimentacaoContabil/{dataInicial}/{dataFinal}")]
    public async Task<object> MovimentacaoContabil(string dataInicial, string dataFinal)
    {
        DateOnly.TryParse(dataInicial, out var dataInicialOut);
        DateOnly.TryParse(dataFinal, out var dataFinalOut);
        var despesaReceita = await _utilService.DespesaReceita(dataInicialOut, dataFinalOut);

        return despesaReceita;
    }

}
