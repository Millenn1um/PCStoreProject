namespace PCStore.Services
{
    public interface IBusinessService
    {
        decimal GetTotalInventoryValue();
        int GetTotalProductsCount();
    }
}
