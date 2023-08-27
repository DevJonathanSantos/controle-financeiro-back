using ControleFinanceiro.Business.Interfaces.Repository;
using ControleFinanceiro.Business.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.Core.Models;

namespace ControleFinanceiro.Business.UseCases.Parcels.GetParcelsGroupedByMonth;

public class GetParcelsGroupedByMonthResponse
{
    public IEnumerable<ParcelsGroupedByMonth> ParcelsGroupedByMonths { get; private set; }

    public void Add(IEnumerable<ParcelsGroupedByMonth> parcelsGroupedByMonths)
    {
        ParcelsGroupedByMonths = parcelsGroupedByMonths;
    }
}

public class ParcelsGroupedByMonth
{
    public int Month { get; set; }
    public bool IsCurrentMonth { get; set; }
    public decimal TotalMonth { get; set; }
    public IEnumerable<Parcel> Parcels { get; set; }
}