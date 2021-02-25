using System;

namespace WarehouseDocumentApplication
{
    public class WarehouseDocumentFilterClass
    {
        public WarehouseDocumentFilterClass()
        {
            DateStart = DateTime.Today;
            DateStop = DateTime.Today;
        }

        public DateTime DateStart { get; set; }
        public bool IsDateStartEnabled { get; set; }
        public DateTime DateStop { get; set; }
        public bool IsDateStopEnabled { get; set; }
        public string CustomerNumber { get; set; }
        public string DocumentName { get; set; }
        public string ProductName { get; set; }
    }
}
