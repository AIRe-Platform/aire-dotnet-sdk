// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using Aire.Sdk.Models.Resources;
using Aire.Sdk.Platform.Clients.Models;
using Microsoft.AspNetCore.Http;

namespace Aire.Sdk.Platform.Clients;

public interface IAireAiClient
{
    /// <summary>
    /// Queries questionnaires by a set of keywords.
    /// </summary>
    /// <param name="keywords"></param>
    /// <returns>List of questionnaire IDs sorted by relevance</returns>
    public abstract Task<QuestionnaireQueryResponse?> QueryQuestionnaires(IEnumerable<string> keywords);

    /// <summary>
    /// Embeds questionnaire for RAG and similarity search
    /// </summary>
    /// <param name="questionnaire">Questionnaire object</param>
    /// <returns>Document IDs</returns>
    public abstract Task<EmbeddingResponse?> CreateQuestionnaireEmbedding(Questionnaire questionnaire);

    /// <summary>
    /// Removes questionnaire embedding
    /// </summary>
    /// <param name="id">Document ID received after embedding</param>
    /// <returns>True if request succeeded, otherwise false</returns>
    public abstract Task<bool> DeleteQuestionnaireEmbedding(string id);

    /// <summary>
    /// Search content with similarity search
    /// </summary>
    /// <param name="search">Search string</param>
    /// <returns>List of questionnaire IDs sorted by relevance</returns>
    public abstract Task<ContentQueryResponse?> SearchContent(string search);

    /// <summary>
    /// Embeds content for RAG and similarity search
    /// </summary>
    /// <param name="questionnaire">Questionnaire object</param>
    /// <returns>Document IDs</returns>
    public abstract Task<EmbeddingResponse?> CreateContentEmbedding(Content content);

    /// <summary>
    /// Removes content embedding
    /// </summary>
    /// <param name="id">Document ID received after embedding</param>
    /// <returns>True if request succeeded, otherwise false</returns>
    public abstract Task<bool> DeleteContentEmbedding(string id);

    /// <summary>
    /// Embeds contents of a document for RAG
    /// </summary>
    /// <param name="file">File</param>
    /// <param name="metadata">Metadata</param>
    /// <returns></returns>
    public abstract Task<EmbeddingResponse?> CreateDocumentEmbedding(IFormFile file, DocumentMetadata metadata);

    /// <summary>
    /// Removes document embedding
    /// </summary>
    /// <param name="id">Document ID received after embedding</param>
    /// <returns>True if request succeeded, otherwise false</returns>
    public abstract Task<bool> DeleteDocumentEmbedding(string id);
}