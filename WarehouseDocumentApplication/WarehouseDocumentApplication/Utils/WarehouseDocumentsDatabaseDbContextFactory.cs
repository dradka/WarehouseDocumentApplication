using Microsoft.EntityFrameworkCore;
using WarehouseDocumentApplication.Configuration;
using WarehouseDocumentApplication.Login;
using WarehouseDocumentApplication.Models;

namespace WarehouseDocumentApplication.Utils
{
    public class WarehouseDocumentsDatabaseDbContextFactory
    {
        private RootObject _configurationItem;

        public WarehouseDocumentsDatabaseDbContextFactory(LoginControlClass loginControlClass)
        {
            _configurationItem = loginControlClass.ConfigurationItem;
        }
        public WarehouseDocumentsDatabaseContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseDocumentsDatabaseContext>(); 
            optionsBuilder.UseSqlServer(_configurationItem.ConnectionStrings.WarehouseDocumentsDatabase);
            return new WarehouseDocumentsDatabaseContext(optionsBuilder.Options);
        }
    }
}
