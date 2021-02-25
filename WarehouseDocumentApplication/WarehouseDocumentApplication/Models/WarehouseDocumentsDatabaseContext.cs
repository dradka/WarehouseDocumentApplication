using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WarehouseDocumentApplication.Models
{
    public partial class WarehouseDocumentsDatabaseContext : DbContext
    {
        public WarehouseDocumentsDatabaseContext(DbContextOptions<WarehouseDocumentsDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WarehouseDocumentHeader> WarehouseDocumentHeaders { get; set; }
        public virtual DbSet<WarehouseDocumentPosition> WarehouseDocumentPositions { get; set; }

        public async Task<int> GetWarehouseDocumentHeaderSequenceNextValue()
        {
            var p = new SqlParameter("@result", System.Data.SqlDbType.Int);
            p.Direction = System.Data.ParameterDirection.Output;
            await Database.ExecuteSqlRawAsync("set @result = next value for [dbo].[WarehouseDocumentHeaderSequence]", p);
            return (int)p.Value;
        }

        public async Task<int> GetWarehouseDocumentPositionSequenceNextValue()
        {
            var p = new SqlParameter("@result", System.Data.SqlDbType.Int);
            p.Direction = System.Data.ParameterDirection.Output;
            await Database.ExecuteSqlRawAsync("set @result = next value for [dbo].[WarehouseDocumentPositionSequence]", p);
            return (int)p.Value;
        }
    }
}
