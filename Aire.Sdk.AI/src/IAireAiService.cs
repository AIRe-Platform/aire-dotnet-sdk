using Aire.Sdk.AI.Models;
using Aire.Sdk.Models.Identity;
using Aire.Sdk.Models.Resources;
using Aire.Sdk.Models.Platform;

namespace Aire.Sdk.AI
{
    public interface IAireAiService
    {
        /// <summary>
        /// Configure which AI module to call
        /// </summary>
        /// <param name="serviceModule">Module configuration object</param>
        /// <param name="userServiceCredentials">Optional user credentials if the service requires user authentication</param>
        public abstract void UseModule(Module serviceModule, UserServiceCredentials? userServiceCredentials = null);

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
}