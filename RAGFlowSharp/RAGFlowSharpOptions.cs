using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using RAGFlowSharp;
using RAGFlowSharp.Api;
using WebApiClientCore.Extensions.OAuths;

namespace RAGFlowSharp
{
    /// <summary>
    /// Configuration options for the RAGFlow Sharp client.
    /// </summary>
    public class RAGFlowSharpOptions
    {
        /// <summary>
        /// api key for ragflow
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;

        /// <summary>
        /// the base url for ragflow api, default is https://demo.ragflow.io/
        /// </summary>
        public string BaseUrl { get; set; } = "https://demo.ragflow.io/";

        /// <summary>
        /// whether to enable the log
        /// </summary>
        public bool EnableLogging { get; set; } = false;
    }
}

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for configuring RAGFlow Sharp services.
    /// </summary>
    public static class RAGFlowSharpServiceCollectionExtensions
    {
        /// <summary>
        /// Adds and configures RAGFlow Sharp services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <param name="setupAction">An action to configure the <see cref="RAGFlowSharpOptions"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddRagflowSharp(this IServiceCollection services,
            Action<RAGFlowSharpOptions> setupAction)
        {
            return services.Configure(setupAction).ConfigureRagflowSharp();
        }

        /// <summary>
        /// Adds and configures RAGFlow Sharp services with custom token provider to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <param name="setupAction">An action to configure the <see cref="RAGFlowSharpOptions"/>.</param>
        /// <param name="tokenProvider">Custom token provider delegate.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddRagflowSharp(this IServiceCollection services,
            Action<RAGFlowSharpOptions> setupAction,
            Func<IServiceProvider, Task<TokenResult>> tokenProvider)
        {
            return services.Configure(setupAction).ConfigureRagflowSharp(tokenProvider);
        }

        /// <summary>
        /// Configures RAGFlow Sharp services with the current options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure services in.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection ConfigureRagflowSharp(this IServiceCollection services)
        {
            return ConfigureRagflowSharp(services, DefaultTokenProvider);
        }

        /// <summary>
        /// Configures RAGFlow Sharp services with a custom token provider.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure services in.</param>
        /// <param name="tokenProvider">Custom token provider delegate.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection ConfigureRagflowSharp(this IServiceCollection services,
            Func<IServiceProvider, Task<TokenResult>> tokenProvider)
        {
            services.AddHttpApi<IRagflowApi>((options, sp) =>
                {
                    var ragflowOptions = sp.GetRequiredService<IOptions<RAGFlowSharpOptions>>().Value;
                    options.HttpHost = new Uri(ragflowOptions.BaseUrl);

                    var snakeCaseNamingPolicy = new SnakeCaseNamingPolicy();

                    // 序列化配置
                    options.JsonDeserializeOptions.IgnoreNullValues = true;
                    options.JsonDeserializeOptions.PropertyNamingPolicy = snakeCaseNamingPolicy;
                    options.JsonDeserializeOptions.Converters.Add(new JsonStringEnumConverter(snakeCaseNamingPolicy));

                    options.JsonSerializeOptions.IgnoreNullValues = true;
                    options.JsonSerializeOptions.PropertyNamingPolicy = snakeCaseNamingPolicy;
                    options.JsonSerializeOptions.Converters.Add(new JsonStringEnumConverter(snakeCaseNamingPolicy));

                    options.KeyValueSerializeOptions.IgnoreNullValues = true;
                    options.KeyValueSerializeOptions.PropertyNamingPolicy = snakeCaseNamingPolicy;
                    options.KeyValueSerializeOptions.Converters.Add(new JsonStringEnumConverter(snakeCaseNamingPolicy));

                    options.UseLogging = ragflowOptions.EnableLogging;
                });

            services.AddTokenProvider<IRagflowApi>(tokenProvider);

            return services;
        }

        /// <summary>
        /// Default token provider implementation that extracts token from HTTP context and configuration.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>A task that represents the asynchronous operation and contains the token result.</returns>
        private static Task<TokenResult> DefaultTokenProvider(IServiceProvider serviceProvider)
        {
            var token = ExtractTokenFromHttpContext(serviceProvider) 
                        ?? ExtractTokenFromConfiguration(serviceProvider) 
                        ?? string.Empty;

            return Task.FromResult(new TokenResult
            {
                Access_token = token,
                Token_type = "Bearer"
            });
        }

        /// <summary>
        /// Extracts token from HTTP context headers (Authorization or api_key).
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The extracted token or null if not found.</returns>
        private static string? ExtractTokenFromHttpContext(IServiceProvider serviceProvider)
        {
            var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
            if (httpContextAccessor?.HttpContext == null)
                return null;

            var headers = httpContextAccessor.HttpContext.Request.Headers;
            
            // 优先检查 Authorization header
            if (headers.TryGetValue("Authorization", out var authorizationHeader) 
                && !StringValues.IsNullOrEmpty(authorizationHeader))
            {
                var authValue = authorizationHeader.ToString();
                if (authValue.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    return authValue.Substring(7); // Remove "Bearer " prefix
                }
            }

            // 检查 api_key header
            if (headers.TryGetValue("api_key", out var apiKeyHeader) 
                && !StringValues.IsNullOrEmpty(apiKeyHeader))
            {
                return apiKeyHeader.ToString();
            }

            return null;
        }

        /// <summary>
        /// Extracts token from RAGFlow configuration options.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The configured API key or null if not set.</returns>
        private static string? ExtractTokenFromConfiguration(IServiceProvider serviceProvider)
        {
            var ragflowOptions = serviceProvider.GetRequiredService<IOptions<RAGFlowSharpOptions>>().Value;
            return string.IsNullOrEmpty(ragflowOptions.ApiKey) ? null : ragflowOptions.ApiKey;
        }
    }
}