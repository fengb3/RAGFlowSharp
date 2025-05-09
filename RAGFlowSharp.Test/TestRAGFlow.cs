using JetBrains.Annotations;
using RAGFlowSharp.Api;

namespace RAGFlowSharp.Test;

[TestSubject(typeof(IRagflowApi))]
public class TestRAGFlow(IRagflowApi ragflowApi)
{
    [Fact]
    public void TestRagflowApi()
    {
        Assert.NotNull(ragflowApi);
    }
}