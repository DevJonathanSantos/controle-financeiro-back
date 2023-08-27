using ControleFinanceiro.Business.UseCases.Expenses.Get;
using ControleFinanceiro.Business.Wrappers;
using ControleFinanceiro.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParcelController : BaseController
{
    private readonly IMediator _mediator;

    public ParcelController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet("parcels-grouped-by-month")]
    [ProducesResponseType(typeof(ApiResult<IEnumerable<Expense>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExpenses()
    {
        var query = new GetParcelsGroupedByMonthQuery();

        return ToHttpResult(await _mediator.Send(query));
    }
}
