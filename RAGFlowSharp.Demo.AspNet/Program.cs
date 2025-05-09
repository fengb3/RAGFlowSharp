using RAGFlowSharp.Api;
using RAGFlowSharp.Dtos.Dataset;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRagflowSharp(options =>
{
    options.ApiKey = "ragflow-A4YTJjODc4MmMwMDExZjA5YTQ1NDIwMT";
    options.BaseUrl = "https://demo.ragflow.io";
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

// 创建数据集
app.MapPost("/api/datasets", async (IRagflowApi api, Create.RequestBody request) =>
{
    try
    {
        var result = await api.CreateDataset(request);
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

// 删除数据集
app.MapDelete("/api/datasets", async (IRagflowApi api, Delete.RequestBody request) =>
{
    try
    {
        var result = await api.DeleteDataset(request);
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.Run();