namespace WarehouseDocumentApplication.Utils
{
    public interface IHasControlClass<T> where T : BaseControlClass
    {
        T ControlClass { get; set; }
    }
}
