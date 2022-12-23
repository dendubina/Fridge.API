using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using StackExchange.Redis;

namespace FridgeManager.FridgesMicroService.Extensions
{
    public static class RedisDatabaseExtensions
    {
        public static async Task<IEnumerable<T>> GetCachedListFromJsonAsync<T>(this IDatabase redis, string keyName) where T : class
        {
            if (keyName is null)
            {
                throw new ArgumentException("keyName must be not null");
            }

            var json = await redis.StringGetAsync(keyName);

            return string.IsNullOrWhiteSpace(json) ? Array.Empty<T>() : JsonSerializer.Deserialize<IEnumerable<T>>(json);
        }

        public static async Task SetListToJsonStringAsync<T>(this IDatabase redis, string keyName, TimeSpan expire, IEnumerable<T> data) where T : class
        {
            if (keyName is null)
            {
                throw new ArgumentException("keyName must be not null");
            }

            var setTask = redis.StringSetAsync(keyName, JsonSerializer.Serialize(data));
            var expireTask = redis.KeyExpireAsync(keyName, expire);

            await Task.WhenAll(setTask, expireTask);
        }
    }
}
