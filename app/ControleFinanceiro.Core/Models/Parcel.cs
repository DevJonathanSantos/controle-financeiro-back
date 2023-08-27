using ControleFinanceiro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Models;

public class Parcel:IEntity
{
    public int Id { get; set; }
    public DateTime DateParcel { get; set; }
    public decimal Value { get; set; }
    public int ExpenseId { get; set; }
    public Expense Expense { get; set; }
}
