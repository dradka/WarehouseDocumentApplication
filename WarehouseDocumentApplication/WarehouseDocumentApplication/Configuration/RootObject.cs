using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDocumentApplication.Configuration
{
   public class RootObject
   {
       public ConnectionStrings ConnectionStrings { get; set; }
   }

   public class ConnectionStrings
   {
      public string WarehouseDocumentsDatabase { get; set; }
   }
}
