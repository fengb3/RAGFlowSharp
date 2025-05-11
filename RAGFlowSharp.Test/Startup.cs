using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.DependencyInjection.Logging;

namespace RAGFlowSharp.Test;

class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRagflowSharp(options =>
        {
            // options.ApiKey = "ragflow-U3MTFkNGFjMmMyNjExZjA5NjUxMDI0Mm";
            // options.BaseUrl = "http://localhost";
            
            options.ApiKey = "ragflow-U3MTFkNGFjMmMyNjExZjA5NjUxMDI0Mm";
            options.BaseUrl = "http://localhost";
            options.EnableLogging = true;
        });
        
        services.AddLogging(lb =>
        {
            lb.AddXunitOutput();
        });
    }
}