using System.Collections.Generic;

namespace WarehouseDocumentApplication.Utils
{
    public class ContainsIdClassComparer<T> : IEqualityComparer<T>
        where T : IContainsId
    {
        public bool Equals(T x, T y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.Id == y.Id;
        }

        public int GetHashCode(T t) => t.Id;
    }
}