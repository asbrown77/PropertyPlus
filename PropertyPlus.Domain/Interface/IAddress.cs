namespace PropertyPlus.Interface
{
    public interface IAddress
    {
        string Street { get; }
        string Town { get; }
        string PostCode { get; }
        int Number { get; }
    }
}