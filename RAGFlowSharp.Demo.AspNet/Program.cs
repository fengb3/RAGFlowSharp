using RAGFlowSharp.Api;
using RAGFlowSharp.Dtos.Dataset;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddMcpServer()
            .WithToolsFromAssembly()
            .WithHttpTransport();
 
builder.Services.AddRagflowSharp(options =>
{
    options.ApiKey = builder.Configuration["RagFlow:ApiKey"]?? string.Empty;
    options.BaseUrl = builder.Configuration["RagFlow:ApiUrl"] ?? "https://demo.ragflow.io/";
    options.EnableLogging = true;
});

var app = builder.Build();

// 获取数据集列表
app.MapGet("/api/datasets", async (IRagflowApi api) =>
{
    try
    {
        var result = await api.ListDatasets();
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});


app.MapMcp();
app.Run();