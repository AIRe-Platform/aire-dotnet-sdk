using Aire.Sdk.AspNetCore;
using Aire.Sdk.Models.Platform;
using Aire.Sdk.Models.Resources;
using Microsoft.Extensions.Logging;

namespace Aire.Sdk.Platform.Clients;

public class AireAiClient : AireClientBase, IAireAiClient
{
    private readonly ILogger<AireAiClient> _log;

    public AireAiClient(HttpClient httpclient, Module serviceModule, string? accessToken, ILogger<AireAiClient> log)
        : base(httpclient, serviceModule, accessToken)
    {
        _log = log;
    }

    public async Task<QuestionnaireQueryResponse?> QueryQuestionnaires(IEnumerable<string> keywords)
    {
        var query = new Dictionary<string, string?> {
            { "query", string.Join(",", keywords ) }
        };
        string path = "embeddings/questionnaire" + QueryString.FromDictionary(query);
        var req = new HttpRequestMessage(HttpMethod.Get, path);
        var response = await _httpClient.SendAsync(req);

        if (response.IsSuccessStatusCode)
            return await response.ReadJsonResponse<QuestionnaireQueryResponse>();

        await LogIfErrorResponse(response, _log);
        return default;
    }

    public async Task<EmbeddingResponse?> EmbedQuestionnaire(Questionnaire questionnaire)
    {
        var req = new HttpRequestMessage(HttpMethod.Post, "embeddings/questionnaire")
        {
            Content = new JsonContent<Questionnaire>(questionnaire)
        };
        var response = await _httpClient.SendAsync(req);

        if (response.IsSuccessStatusCode)
            return await response.ReadJsonResponse<EmbeddingResponse>();

        await LogIfErrorResponse(response, _log);
        return default;
    }
    
    public async Task<bool> DeleteQuestionnaireEmbedding(string id)
    {
        var req = new HttpRequestMessage(HttpMethod.Delete, $"embeddings/questionnaire/{id}");
        var response = await _httpClient.SendAsync(req);

        await LogIfErrorResponse(response, _log);
        return response.IsSuccessStatusCode;
    }
}