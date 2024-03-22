namespace Aire.Sdk.Auth
{
    public class AireScopes : List<string>
    {
        public const string ReadProfile = "profile-read";
        public const string EditProfile = "profile-edit";
        public const string DeleteProfile = "profile-delete";
        public const string ConnectProfile = "profile-connect";
        public static readonly AireScopes Profile = [ReadProfile, EditProfile, DeleteProfile, ConnectProfile];

        public const string ReadChatHistory = "chat-history-read";
        public const string WriteChatHistory = "chat-history-write";
        public const string DeleteChatHistory = "chat-history-delete";
        public static readonly AireScopes ChatHistory = [ReadChatHistory, WriteChatHistory, DeleteChatHistory];

        public const string ReadQuestionnaire = "questionnaire-read";
        public const string WriteQuestionnaire = "questionnaire-write";
        public const string DeleteQuestionnaire = "questionnaire-delete";
        public static readonly AireScopes Questionnaire = [ReadQuestionnaire, WriteQuestionnaire, DeleteQuestionnaire];

        public const string ReadContent = "content-read";
        public const string WriteContent = "content-write";
        public const string DeleteContent = "content-delete";
        public static readonly AireScopes Content = [ReadContent, WriteContent, DeleteContent];

        public const string ReadDocument = "document-read";
        public const string WriteDocument = "document-write";
        public const string DeleteDocument = "document-delete";
        public static readonly AireScopes Document = [ReadDocument, WriteDocument, DeleteDocument];

        public const string ChatCompletion = "chat-completion";
        public const string ChatSummary = "chat-summary";
        public const string ChatTokenCount = "chat-token-count";
        public static readonly AireScopes ChatBot = [ChatCompletion, ChatSummary, ChatTokenCount];

        public const string ReadDemoGroups = "demo-group-read";
        public const string EditDemoGroups = "demo-group-write";
        public const string DeleteDemoGroups = "demo-group-delete";
        public static readonly AireScopes DemoGroups = [ReadDemoGroups, EditDemoGroups, DeleteDemoGroups];

        public const string AireHub = "aire-hub";
        public const string PasswordChange = "password-change";
        public const string AdminAccounts = "admin-accounts";

        public static readonly AireScopes AdminScopes = new(
            Profile,
            ChatHistory,
            ChatBot,
            Questionnaire,
            Content,
            Document,
            DemoGroups,
            AireHub,
            PasswordChange,
            AdminAccounts
        );

        public static readonly AireScopes UserScopes = new(
            Profile,
            ChatHistory,
            ChatBot,
            ReadQuestionnaire,
            ReadContent,
            ReadDocument,
            PasswordChange
        );

        public static readonly AireScopes DemoAdminScopes = new(
            UserScopes,
            DemoGroups,
            AireHub
        );

        public static readonly AireScopes DemoUserScopes = new(
            ReadProfile,
            EditProfile,
            ChatBot,
            ChatHistory,
            ReadQuestionnaire,
            ReadContent
        );

        public static readonly Dictionary<string, AireScopes> DefaultRoleScopes = new() {
            { AireRoles.User, UserScopes },
            { AireRoles.Admin, AdminScopes },
            { AireRoles.DemoAdmin, DemoAdminScopes },
            { AireRoles.DemoUser, DemoUserScopes }
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
