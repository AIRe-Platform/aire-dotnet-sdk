namespace Aire.Sdk.Auth.Scopes
{
    public class AireScopes : List<string>
    {
        public const string ReadProfile = "profile-read";
        public const string EditProfile = "profile-edit";
        public const string DeleteProfile = "profile-delete";
        public static readonly AireScopes Profile = [ ReadProfile, EditProfile, DeleteProfile ];

        public const string ReadChatHistory = "chat-history-read";
        public const string WriteChatHistory = "chat-history-write";
        public const string DeleteChatHistory = "chat-history-delete";
        public static readonly AireScopes ChatHistory = [ ReadChatHistory, WriteChatHistory, DeleteChatHistory ];

        public const string ReadQuestionnaire = "questionnaire-read";
        public const string WriteQuestionnaire = "questionnaire-write";
        public const string DeleteQuestionnaire = "questionnaire-delete";
        public static readonly AireScopes Questionnaire = [ ReadQuestionnaire, WriteQuestionnaire, DeleteQuestionnaire ];

        public const string ChatCompletion = "chat-completion";
        public const string ChatSummary = "chat-summary";
        public const string ChatEmbeddings = "chat-embeddings";
        public const string ChatTokenCount = "chat-token-count";
        public static readonly AireScopes ChatBot = [ ChatCompletion, ChatSummary, ChatTokenCount ];
        public static readonly AireScopes ChatBotAdmin = [ ChatEmbeddings ];

        public const string UnverifiedAccount = "unverified-account";
        public const string EulaRequired = "eula-required";

        public static readonly AireScopes UserScopes = new AireScopes(Profile, ChatHistory, ChatBot, Questionnaire);
        public static readonly AireScopes All = new AireScopes(Profile, ChatHistory, ChatBot, ChatBotAdmin, Questionnaire);

        public AireScopes() : base() {}
        public AireScopes(params string[] scopes) : base(scopes) {}
        public AireScopes(params AireScopes[] scopes) 
        {
            foreach(var list in scopes)
                AddRange(list);
        }
    }
}
