using ControleFinanceiro.Business.Interfaces.Repository;
using ControleFinanceiro.Business.Wrappers;
using ControleFinanceiro.Core.Models;
using MediatR;

namespace ControleFinanceiro.Business.UseCases.Expenses.Add;

public class AddExpenseHandler : IRequestHandler<AddExpenseCommand, ApiResult>
{
    private IExpenseRepository _repository;

    public AddExpenseHandler(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<ApiResult> Handle(AddExpenseCommand command, CancellationToken cancellationToken)
    {
        var apiResult = new ApiResult();
        var data = DateTime.Now;
        var valorPorPacela = Math.Round(command.Value / command.QuantityParcels, 2);
        var parcels= new List<Parcel>();

        for (int i = 0; i < command.QuantityParcels; i++)
        {
            parcels.Add(new Parcel
            {
                Value = valorPorPacela,
                DateParcel = data,
            });
        }

        var expense = new Expense
        {
            DateRegistered = command.DateRegistered,
            Value = command.Value,
            CategoryId = command.CategoryId,
            TypePayment = command.TypePayment?.ToString(),
            Parcels= parcels
        };

        await _repository.Add(expense);
        await _repository.Save();

        return  apiResult;
    }
}
