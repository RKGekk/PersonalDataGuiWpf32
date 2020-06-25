using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository {

    public class ObjectCache<T> where T : class {

        private readonly ObjectCache _cacheObjects = new MemoryCache(nameof(T));
        private static readonly int _cacheExpirationInMilliseconds;

        static ObjectCache() {
            int expirationCache = int.TryParse(ConfigurationManager.AppSettings["ExpirationCacheInMilliseconds"], out expirationCache) ? expirationCache : 60000;
            _cacheExpirationInMilliseconds = expirationCache;
        }

        private DateTimeOffset ExpirationTimeCacheEntry
            => new DateTimeOffset(DateTime.Now.AddMinutes(_cacheExpirationInMilliseconds));

        public T Get(string key)
            => (T)_cacheObjects[key];

        public T Get(string key, Func<T> onMiss)
            => Get(key) ?? AddValueToCache(key, onMiss);

        public void Reset(string key)
            => _cacheObjects.Remove(key);

        private T AddValueToCache(string key, Func<T> onMissFunction) {

            T result = onMissFunction();

            if (result != null) {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = ExpirationTimeCacheEntry;

                _cacheObjects.Set(key, result, policy);
            }

            return result;
        }
    }
}
