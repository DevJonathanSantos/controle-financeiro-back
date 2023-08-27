using ControleFinanceiro.Business.UseCases.Expenses.Add;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : BaseController
{
    private readonly IMediator _mediator;

    public ExpenseController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet("expenses-of-the-year")]
    public Task<IActionResult> GetExpensesOfTheYear()
    {
        return null;
    }

    //[HttpGet("expenses")]
    //[ProducesResponseType(typeof(ApiResult<IEnumerable<Expense>>), StatusCodes.Status200OK)]
    //public async Task<IActionResult> GetExpenses()
    //{
    //    var query = new GetExpenseQuery();

    //    return ToHttpResult(await _mediator.Send(query));
    //}

    [HttpGet("expenses-by-month")]
    public Task<IActionResult> GetExpensesByMonth()
    {
        return null;
    }

    [HttpPost]
    public async Task<IActionResult> AddExpense([FromBody] AddExpenseCommand command)
    {
        await _mediator.Send(command);

        return ToHttpResult(await _mediator.Send(command));
    }

    [HttpPut("expense")]
    public Task<IActionResult> UpdateExpense()
    {
        return null;
    }
}
