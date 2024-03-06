using Aire.Sdk.Models.Resources;

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
    public abstract Task<EmbeddingResponse?> EmbedQuestionnaire(Questionnaire questionnaire);

    /// <summary>
    /// Removes questionnaire embedding
    /// </summary>
    /// <param name="id">Document ID received after embedding</param>
    /// <returns>True if request succeeded, otherwise false</returns>
    public abstract Task<bool> DeleteQuestionnaireEmbedding(string id);
}