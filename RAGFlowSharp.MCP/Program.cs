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

app.MapMcp();
app.Run();