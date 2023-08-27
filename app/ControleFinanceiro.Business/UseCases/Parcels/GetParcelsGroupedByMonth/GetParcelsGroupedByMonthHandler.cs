using ControleFinanceiro.Business.Interfaces.Repository;
using ControleFinanceiro.Business.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleFinanceiro.Core.Models;
using ControleFinanceiro.Business.UseCases.Expenses.Get;
using System.Globalization;

namespace ControleFinanceiro.Business.UseCases.Parcels.GetParcelsGroupedByMonth;

public class GetParcelsGroupedByMonthHandler : IRequestHandler<GetParcelsGroupedByMonthQuery, ApiResult<IEnumerable<ParcelsGroupedByMonth>>>
{
    private readonly IParcelRepository _pacelsRepository;

    public GetParcelsGroupedByMonthHandler(IParcelRepository pacelsRepository)
    {
        _pacelsRepository = pacelsRepository;
    }

    public async Task<ApiResult<IEnumerable<ParcelsGroupedByMonth>>> Handle(GetParcelsGroupedByMonthQuery request, CancellationToken cancellationToken)
    {
        var apiResult = new ApiResult<IEnumerable<ParcelsGroupedByMonth>>();

        var parcels = await _pacelsRepository.GetAll();

        var parcelsGroupedByMonths = parcels
                    .GroupBy(p => p.DateParcel.Month)
                    .Select(g => new ParcelsGroupedByMonth
                    {
                        Month = g.Key,
                        TotalMonth = g.Sum(p => p.Value),
                        Parcels = g.ToList(),
                        IsCurrentMonth = (DateTime.Now.Month == g.Key)

                    }).ToList();

        AddPendingMonths(parcelsGroupedByMonths);

        return apiResult.SetData(parcelsGroupedByMonths.OrderBy(o => o.Month));
    }

    private static void AddPendingMonths(List<ParcelsGroupedByMonth> parcelsGroupedByMonths)
    {
        for (int i = 1; i <= 12; i++)
        {
            if (!parcelsGroupedByMonths.Any(a => a.Month == i))
                parcelsGroupedByMonths.Add(new ParcelsGroupedByMonth
                {
                    Month = i,
                });
        }
    }
}
