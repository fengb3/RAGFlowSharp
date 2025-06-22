using ModelContextProtocol.Server;
using RAGFlowSharp.Api;
using RAGFlowSharp.Dtos.Dataset;
using System.ComponentModel;

namespace RAGFlowSharp.Demo.AspNet.Tools
{
    [McpServerToolType()]
    public sealed class ListDatasetsTool
    {
        [McpServerTool(Name ="listdatasets"), Description("Lists datasets available in the current system.")]
        public static async Task<List.ResponseBody> ListDatasets(IRagflowApi ragflowApi)
        {
            var response = await ragflowApi.ListDatasets(); 
            return response;
        } 
    }
}
