using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
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
        /// Configures RAGFlow Sharp services with the current options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure services in.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection ConfigureRagflowSharp(this IServiceCollection services)
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
                })
                ;

            services.AddTokenProvider<IRagflowApi>(sp =>
            {
                var ragflowOptions = sp.GetRequiredService<IOptions<RAGFlowSharpOptions>>().Value;
                return Task.FromResult(new TokenResult
                {
                    Access_token = ragflowOptions.ApiKey,
                    Token_type = "Bearer",
                })!;
            });

            return services;
        }
    }
}

// namespace RAGFlowSharp.Api
// {
//     public interface IRagflowApi : IDatasetApi
//     {
//     }
// }