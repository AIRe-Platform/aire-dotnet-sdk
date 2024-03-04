using Aire.Sdk.Auth.Roles;

namespace Aire.Sdk.Auth.Scopes
{
    public class AireScopes : List<string>
    {
        public const string ReadProfile = "profile-read";
        public const string EditProfile = "profile-edit";
        public const string DeleteProfile = "profile-delete";
        public static readonly AireScopes Profile = [ReadProfile, EditProfile, DeleteProfile];

        public const string ReadChatHistory = "chat-history-read";
        public const string WriteChatHistory = "chat-history-write";
        public const string DeleteChatHistory = "chat-history-delete";
        public static readonly AireScopes ChatHistory = [ReadChatHistory, WriteChatHistory, DeleteChatHistory];

        public const string ReadQuestionnaire = "questionnaire-read";
        public const string WriteQuestionnaire = "questionnaire-write";
        public const string DeleteQuestionnaire = "questionnaire-delete";
        public static readonly AireScopes Questionnaire = [ReadQuestionnaire, WriteQuestionnaire, DeleteQuestionnaire];

        public const string ReadDocument = "document-read";
        public const string WriteDocument = "document-write";
        public const string DeleteDocument = "document-delete";
        public static readonly AireScopes Document = [ReadDocument, WriteDocument, DeleteDocument];

        public const string ChatCompletion = "chat-completion";
        public const string ChatSummary = "chat-summary";
        public const string ChatTokenCount = "chat-token-count";
        public static readonly AireScopes ChatBot = [ChatCompletion, ChatSummary, ChatTokenCount];

        public const string ReadResearchSubject = "research-subject-read";
        public const string WriteResearchSubject = "research-subject-write";
        public const string DeleteResearchSubject = "research-subject-delete";
        public static readonly AireScopes ResearchSubjects = [ReadResearchSubject, WriteResearchSubject, DeleteResearchSubject];

        public const string AireHub = "aire-hub";
        public const string UnverifiedAccount = "unverified-account";
        public const string EulaRequired = "eula-required";

        public static readonly AireScopes AdminScopes = new(
            Profile,
            ChatHistory,
            ChatBot,
            Questionnaire,
            Document,
            ResearchSubjects,
            AireHub
        );

        public static readonly AireScopes UserScopes = new(
            Profile,
            ChatHistory,
            ChatBot,
            ReadQuestionnaire,
            ReadDocument
        );

        public static readonly AireScopes ResearcherScopes = new(
            UserScopes,
            ResearchSubjects,
            AireHub
        );

        public static readonly AireScopes ResearchSubjectScopes = new(
            ReadProfile,
            EditProfile,
            ChatBot,
            ChatHistory,
            ReadQuestionnaire
        );

        public static readonly Dictionary<string, AireScopes> DefaultRoleScopes = new() {
            { AireRoles.User, UserScopes },
            { AireRoles.Admin, AdminScopes },
            { AireRoles.Researcher, ResearcherScopes },
            { AireRoles.ResearchSubject, ResearchSubjectScopes}
        };

        public AireScopes() : base() { }
        public AireScopes(params dynamic[] collection) : base()
        {
            foreach (var item in collection)
            {
                if (item is string)
                    Add(item);
                else if (item is AireScopes)
                    AddRange(item);
                else 
                    throw new ArgumentException("Unsupported argument");
            }
        }
    }
}
