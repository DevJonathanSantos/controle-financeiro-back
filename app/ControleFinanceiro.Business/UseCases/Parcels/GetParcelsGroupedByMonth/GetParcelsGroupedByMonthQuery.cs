using ControleFinanceiro.Business.Interfaces.Repository;
using ControleFinanceiro.Business.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.Core.Models;
using ControleFinanceiro.Business.UseCases.Parcels.GetParcelsGroupedByMonth;

namespace ControleFinanceiro.Business.UseCases.Expenses.Get;

public class GetParcelsGroupedByMonthQuery : IRequest<ApiResult<IEnumerable<ParcelsGroupedByMonth>>>
{
   
}
