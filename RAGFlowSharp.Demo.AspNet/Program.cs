using RAGFlowSharp.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRagflowSharp(options =>
{
    options.ApiKey = "ragflow-A4YTJjODc4MmMwMDExZjA5YTQ1NDIwMT";
    options.BaseUrl = "https://demo.ragflow.io";
    options.EnableLogging = true;
});

var app = builder.Build();

app.MapGet("/", (IRagflowApi api) => api.ListDatasets());

app.Run();