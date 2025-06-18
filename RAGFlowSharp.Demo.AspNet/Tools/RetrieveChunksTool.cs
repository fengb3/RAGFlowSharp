using ModelContextProtocol.Server;
using RAGFlowSharp.Api;
using RAGFlowSharp.Dtos.Chunk;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace RAGFlowSharp.Demo.AspNet.Tools
{
    [McpServerToolType()]
    public sealed class RetrieveChunksTool
    {
        [McpServerTool(Name = "Retrieval"), Description($"Retrieve relevant chunks based on the question, using the specified dataset_ids and optionally document_ids. Below is the list of all available datasets, including their descriptions and IDs. If you're unsure which datasets are relevant to the question, simply pass all dataset IDs to the function.")]
        public static async Task<Retrieval.ResponseBody> Retrieval(IRagflowApi ragflowApi,
          [Description("The IDs of the datasets to search"), Required] string dataset_ids,
          [Description("The user query or query keywords"),Required(AllowEmptyStrings = false)] string question)
        {
            var retrievalRequest = new Retrieval.RequestBody
            {
                Question = question,
                DatasetIds = new List<string>() { dataset_ids},
                Page = 1,
                PageSize = 10, 
                Highlight = true
            };
            var retrievalResult = await ragflowApi.RetrieveChunksAsync(retrievalRequest);
            return retrievalResult;
        }
    }
}
