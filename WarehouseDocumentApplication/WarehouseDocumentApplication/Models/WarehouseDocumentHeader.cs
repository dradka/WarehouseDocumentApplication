using System;
using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.Models
{
    public partial class WarehouseDocumentHeader : IContainsId
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string CustomerNumber { get; set; }
        public string DocumentName { get; set; }
        public decimal NetValue { get; set; }
        public decimal GrossValue { get; set; }
    }
}
