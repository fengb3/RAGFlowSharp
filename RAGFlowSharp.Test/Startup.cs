using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection.Logging;

namespace RAGFlowSharp.Test;

class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // 构建配置
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        services.AddSingleton<IConfiguration>(configuration);
        
        // 添加测试用的 HttpContextAccessor
        services.AddSingleton<IHttpContextAccessor, TestHttpContextAccessor>();

        services.AddRagflowSharp(options =>
        {
            // 从环境变量或配置文件中读取设置
            options.ApiKey = Environment.GetEnvironmentVariable("RAGFLOW_API_KEY") 
                           ?? configuration["RAGFlowSharp:ApiKey"] 
                           ?? throw new InvalidOperationException("RAGFLOW_API_KEY environment variable or RAGFlowSharp:ApiKey configuration is required");
            
            options.BaseUrl = Environment.GetEnvironmentVariable("RAGFLOW_BASE_URL") 
                            ?? configuration["RAGFlowSharp:BaseUrl"] 
                            ?? "http://localhost:8000";
            
            options.EnableLogging = true;
        });
        
        services.AddLogging(lb =>
        {
            lb.AddXunitOutput();
        });
        
    }
}