using ControleFinanceiro.Core.Interfaces;

namespace ControleFinanceiro.Core.Models;

public class Category:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Expense> Expenses { get; set; }
}

