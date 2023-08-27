using ControleFinanceiro.Business.Interfaces.Repository;
using ControleFinanceiro.Core.Models;
using ControleFinanceiro.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repositories;

public class ExpenseRepository: Repository<Expense>, IExpenseRepository
{
    public ExpenseRepository(ControleFinanceiroContext context):base(context)
    {

    }
}
