using Microsoft.Extensions.Logging;
using Aire.Sdk.AI.Models;
using Aire.Sdk.Models.Resources;
using Aire.Sdk.Platform;
using Aire.Sdk.Models.Platform;
using Aire.Sdk.Models.Identity;
using Aire.Sdk.AspNetCore;

namespace Aire.Sdk.AI;

public class AireAiService : IAireAiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AireAiService> _log;

    public AireAiService(
        HttpClient httpClient,
        ILogger<AireAiService> log)
    {
        _httpClient = httpClient;
        _log = log;
    }

    public void UseModule(Module serviceModule, UserServiceCredentials? userServiceCredentials = null)
    {
        if (serviceModule.Type != ModuleType.AI)
            throw new AireAiServiceException("The module is not an AI service module");

        _httpClient.ConfigureModuleClient(serviceModule, userServiceCredentials);
    }

    public async Task<QuestionnaireQueryResponse?> QueryQuestionnaires(IEnumerable<string> keywords)
    {
        CheckBaseUrl();

        var query = new Dictionary<string, string?> {
            { "query", string.Join(",", keywords ) }
        };
        string path = "embeddings/questionnaire" + QueryString.FromDictionary(query);
        var req = new HttpRequestMessage(HttpMethod.Get, path);
        var response = await _httpClient.SendAsync(req);

        if (response.IsSuccessStatusCode)
            return await response.ReadJsonResponse<QuestionnaireQueryResponse>();

        await LogIfErrorResponse(response);
        return default;
    }

    public async Task<EmbeddingResponse?> EmbedQuestionnaire(Questionnaire questionnaire)
    {
        CheckBaseUrl();

        var req = new HttpRequestMessage(HttpMethod.Post, "embeddings/questionnaire")
        {
            Content = new JsonContent<Questionnaire>(questionnaire)
        };
        var response = await _httpClient.SendAsync(req);

        if (response.IsSuccessStatusCode)
            return await response.ReadJsonResponse<EmbeddingResponse>();

        await LogIfErrorResponse(response);
        return default;
    }

    public async Task<bool> DeleteQuestionnaireEmbedding(string id)
    {
        CheckBaseUrl();

        var req = new HttpRequestMessage(HttpMethod.Delete, $"embeddings/questionnaire/{id}");
        var response = await _httpClient.SendAsync(req);

        await LogIfErrorResponse(response);
        return response.IsSuccessStatusCode;
    }

    private void CheckBaseUrl()
    {
        if (_httpClient.BaseAddress == null)
            throw new AireAiServiceException("Service module base address missing. Call UseModule before making requests.");
    }

    private async Task LogIfErrorResponse(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return;

        _log.LogError($"Request failed: {response.StatusCode}");
        if (response.Content != null)
        {
            var body = await response.Content.ReadAsStringAsync();
            _log.LogError($"Error response: {body}");
        }
    }
}
