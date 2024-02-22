using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;
using Aire.Sdk.Models.Resources;

namespace Aire.Sdk.Models.Chat
{
    public class ChatState
    {
        [JsonProperty("questionnaire_id", Required = Required.Always)]
        [OpenApiProperty(Description = "Questionnaires unique id")]
        public string? QuestionnaireId { get; set; }

        [JsonProperty("question_queue")]
        [OpenApiProperty(Description = "List of queued questions")]
        public List<QuestionItem>? QuestionQueue { get; set; }
    }
}
