using ControleFinanceiro.Business.Interfaces.Repository;
using ControleFinanceiro.Business.UseCases.Expenses.Add;
using ControleFinanceiro.Business.UseCases.Parcels.GetParcelsGroupedByMonth;
using ControleFinanceiro.Business.Wrappers;
using ControleFinanceiro.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Business.UseCases.Categories.Get;

public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, ApiResult>
{
    private ICategoryRepository _categoryRepository;

    public GetCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<ApiResult> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var apiResult = new ApiResult<IEnumerable<Category>>();

        var categories = await _categoryRepository.GetAll();

        return apiResult.SetData(categories);
    }
}
