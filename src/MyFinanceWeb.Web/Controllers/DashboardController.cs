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
    [HttpGet("MovimentacaoContabil")]
    public object MovimentacaoContabil()
    {
        var despesaReceita = _utilService.DespesaReceita(DateOnly.Parse("2022-01-01"), DateOnly.Parse("2023-12-31"));

        Console.WriteLine(despesaReceita.Receita);
        Console.WriteLine(despesaReceita.Despesa);

        return despesaReceita;
    }

}
