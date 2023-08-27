using ControleFinanceiro.Business.Wrappers;
using MediatR;

namespace ControleFinanceiro.Business.UseCases.Expenses.Add;

public class AddExpenseCommand : IRequest<ApiResult>
{
    public DateTime DateRegistered { get; set; }
    public decimal Value { get; set; }
    public int CategoryId { get; set; }
    public string ? TypePayment { get; set; }
    public int QuantityParcels { get; set; }
}
