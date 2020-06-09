using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Workflows.WebJobs.Extensions.Trigger;
using Newtonsoft.Json.Linq;

namespace Company.Function
{
    public static class EnrichOrderFunction
    {
        [FunctionName("EnrichOrderFunction")]
        public static JToken Run(
           [WorkflowActionTrigger] JToken parameters,
           ILogger log)
        {
            return new JObject { { "Message", "Hello from the workflow triggered function" } };
        }
    }
}
