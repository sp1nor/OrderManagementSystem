using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Ordering.Application.Common.Interfaces;
using Ordering.Application.Common.Settings;
using System.Text;

namespace Ordering.Application.Common.Behaviors
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<TResponse> _logger;
        private readonly CacheSettings _settings;

        public CachingBehavior(
            IDistributedCache cache,
            ILogger<TResponse> logger,
            IOptions<CacheSettings> settings)
        {
            _cache = cache;
            _logger = logger;
            _settings = settings.Value;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is ICacheableMediatrQuery cacheableQuery)
            {
                TResponse response;
                if (cacheableQuery.BypassCache) return await next();
                async Task<TResponse> GetResponseAndAddToCache()
                {
                    response = await next();
                    var slidingExpiration = cacheableQuery.SlidingExpiration == null ? TimeSpan.FromMinutes(_settings.SlidingExpiration) : cacheableQuery.SlidingExpiration;
                    var options = new DistributedCacheEntryOptions { SlidingExpiration = slidingExpiration };
                    var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
                    await _cache.SetAsync(cacheableQuery.CacheKey, serializedData, options, cancellationToken);

                    return response;
                }

                var cachedResponse = await _cache.GetAsync(cacheableQuery.CacheKey, cancellationToken);
                if (cachedResponse != null)
                {
                    response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
                    _logger.LogInformation($"Fetched from Cache -> '{cacheableQuery.CacheKey}'.");
                }
                else
                {
                    response = await GetResponseAndAddToCache();
                    _logger.LogInformation($"Added to Cache -> '{cacheableQuery.CacheKey}'.");
                }

                return response;
            }
            else
            {
                return await next();
            }
        }
    }
}
