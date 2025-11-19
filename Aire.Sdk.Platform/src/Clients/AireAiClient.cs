// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.Net.Http.Headers;
using Aire.Sdk.AspNetCore;
using Aire.Sdk.Models.Platform;
using Aire.Sdk.Models.Resources;
using Aire.Sdk.Platform.Clients.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using QueryString = Aire.Sdk.AspNetCore.QueryString;

namespace Aire.Sdk.Platform.Clients;

public class AireAiClient : AireClientBase, IAireAiClient
{
    private readonly ILogger<AireAiClient> _log;

    public AireAiClient(HttpClient httpclient, Module serviceModule, string? accessToken, ILogger<AireAiClient> log)
        : base(httpclient, serviceModule, accessToken)
    {
        _log = log;
    }

    public async Task<QuestionnaireQueryResponse?> QueryQuestionnaires(string database, IEnumerable<string> keywords)
    {
        var query = new Dictionary<string, string?> {
            { "query", string.Join(",", keywords ) }
        };
        string path = $"embeddings/{database}/questionnaire" + QueryString.FromDictionary(query);
        var req = new HttpRequestMessage(HttpMethod.Get, path);
        var response = await _httpClient.SendAsync(req);

        if (response.IsSuccessStatusCode)
            return await response.ReadJsonResponse<QuestionnaireQueryResponse>();

        await LogIfErrorResponse(response, _log);
        return default;
    }

    public async Task<EmbeddingResponse?> CreateQuestionnaireEmbedding(string database, Questionnaire questionnaire)
    {
        var req = new HttpRequestMessage(HttpMethod.Post, $"embeddings/{database}/questionnaire")
        {
            Content = new JsonContent<Questionnaire>(questionnaire)
        };
        var response = await _httpClient.SendAsync(req);

        if (response.IsSuccessStatusCode)
            return await response.ReadJsonResponse<EmbeddingResponse>();

        await LogIfErrorResponse(response, _log);
        return default;
    }

    public async Task<bool> DeleteQuestionnaireEmbedding(string database, string id)
    {
        var req = new HttpRequestMessage(HttpMethod.Delete, $"embeddings/{database}/questionnaire/{id}");
        var response = await _httpClient.SendAsync(req);

        await LogIfErrorResponse(response, _log);
        return response.IsSuccessStatusCode;
    }

    public async Task<ContentQueryResponse?> SearchContent(string database, string search)
    {
        var query = new Dictionary<string, string?> {
            { "query", search }
        };
        string path = $"embeddings/{database}/content" + QueryString.FromDictionary(query);
        var req = new HttpRequestMessage(HttpMethod.Get, path);
        var response = await _httpClient.SendAsync(req);

        if (response.IsSuccessStatusCode)
            return await response.ReadJsonResponse<ContentQueryResponse>();

        await LogIfErrorResponse(response, _log);
        return default;
    }

    public async Task<EmbeddingResponse?> CreateContentEmbedding(string database, Content content)
    {
        var req = new HttpRequestMessage(HttpMethod.Post, $"embeddings/{database}/content")
        {
            Content = new JsonContent<Content>(content)
        };
        var response = await _httpClient.SendAsync(req);

        if (response.IsSuccessStatusCode)
            return await response.ReadJsonResponse<EmbeddingResponse>();

        await LogIfErrorResponse(response, _log);
        return default;
    }

    public async Task<bool> DeleteContentEmbedding(string database, string id)
    {
        var req = new HttpRequestMessage(HttpMethod.Delete, $"embeddings/{database}/content/{id}");
        var response = await _httpClient.SendAsync(req);

        await LogIfErrorResponse(response, _log);
        return response.IsSuccessStatusCode;
    }

    public async Task<EmbeddingResponse?> CreateDocumentEmbedding(string database, IFormFile file, DocumentMetadata metadata)
    {
        var content = new MultipartFormDataContent
        {
            {
                new StreamContent(file.OpenReadStream()) {
                    Headers = {
                        ContentLength = file.Length,
                        ContentType = new MediaTypeHeaderValue(file.ContentType),
                    }
                }, "document", file.FileName
            },
            {
                new JsonContent<DocumentMetadata>(metadata), "metadata"
            }
        };

        var req = new HttpRequestMessage(HttpMethod.Post, $"embeddings/{database}/document")
        {
            Content = content
        };
        var response = await _httpClient.SendAsync(req);

        if (response.IsSuccessStatusCode)
            return await response.ReadJsonResponse<EmbeddingResponse>();

        await LogIfErrorResponse(response, _log);
        return default;
    }

    public async Task<bool> DeleteDocumentEmbedding(string database, string id)
    {
        var req = new HttpRequestMessage(HttpMethod.Delete, $"embeddings/{database}/document/{id}");
        var response = await _httpClient.SendAsync(req);

        await LogIfErrorResponse(response, _log);
        return response.IsSuccessStatusCode;
    }
}
