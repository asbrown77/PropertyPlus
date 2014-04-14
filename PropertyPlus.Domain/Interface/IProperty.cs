using System;

namespace PropertyPlus.Interface
{
    public interface IProperty
    {
        string Name { get; }
        void AddMortgage(IMortgage mortgage);
        decimal PurchaseAmount { get; }
        DateTime PurchaseDate { get; }
    }
}