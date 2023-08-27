using ControleFinanceiro.Core.Interfaces;

namespace ControleFinanceiro.Core.Models;

public class Expense:IEntity
{
    public int Id { get; set; }
    public DateTime DateRegistered { get; set; }
    public decimal Value { get; set; }
    public string TypePayment { get; set; }
    public int QuantityParcels { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Parcel> Parcels { get; set; }
}




