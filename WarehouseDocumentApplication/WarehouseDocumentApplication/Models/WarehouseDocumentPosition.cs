using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.Models
{
    public partial class WarehouseDocumentPosition : IContainsId
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal NetPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
    }
}
