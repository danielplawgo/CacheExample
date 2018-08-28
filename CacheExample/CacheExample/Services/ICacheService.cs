using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheExample.Services
{
    public interface ICacheService
    {
        T GetOrAdd<T>(string key, Func<T> getFunc);

        T GetOrAdd<T>(string key, string region, Func<T> getFunc);

        void Remove(string key);

        void Remove(string key, string region);

        void Clear();

        void ClearRegion(string region);
    }
}
