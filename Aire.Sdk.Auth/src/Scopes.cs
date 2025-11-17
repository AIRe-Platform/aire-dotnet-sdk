// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


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
        public const string RateContent = "content-rate";
        public static readonly AireScopes Content = [ReadContent, WriteContent, DeleteContent, RateContent];

        public const string ReadReminders = "reminder-read";
        public const string WriteReminders = "reminder-write";
        public const string DeleteReminders = "reminder-delete";
        public static readonly AireScopes Reminders = [ReadReminders, WriteReminders, DeleteReminders];

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

        public const string ReadServices = "services-read";
        public const string EditServices = "services-edit";
        public const string DeleteServices = "services-delete";
        public static readonly AireScopes Services = [ReadServices, EditServices, DeleteServices];

        public const string ReadKeywords = "keywords-read";
        public const string WriteKeywords = "keywords-write";
        public const string DeleteKeywords = "keywords-delete";
        public static readonly AireScopes Keywords = [ReadKeywords, WriteKeywords, DeleteKeywords];

        public const string ReadStatistics = "statistics-read";
        public const string WriteStatistics = "statistics-write";
        public static readonly AireScopes Statistics = [ReadStatistics, WriteStatistics];

        public const string AdminAccounts = "admin-accounts";
        public const string AdminClients = "admin-clients";
        public const string AdminConfig = "admin-config";
        public const string AdminAgents = "admin-agents";
        public const string AdminInstanceSettings = "admin-instance-settings";

        public const string Auth = "auth";
        public const string AireHub = "aire-hub";
        public const string PasswordChange = "password-change";

        public const string ExperimentalCustomPrompt = "experimental-custom-prompt";
        public static readonly AireScopes Experimental = [ExperimentalCustomPrompt];

        public static readonly AireScopes AdminScopes = new(
            Profile,
            ChatHistory,
            ChatBot,
            Questionnaire,
            Content,
            Reminders,
            Document,
            DemoGroups,
            Services,
            AireHub,
            PasswordChange,
            Keywords,
            Statistics,
            AdminAccounts,
            AdminClients,
            AdminConfig,
            AdminAgents,
            AdminInstanceSettings,
            ExperimentalCustomPrompt
        );

        public static readonly AireScopes UserScopes = new(
            Profile,
            ChatHistory,
            ChatBot,
            Reminders,
            ReadQuestionnaire,
            ReadContent,
            RateContent,
            ReadDocument,
            ReadKeywords,
            PasswordChange,
            WriteStatistics
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
            Reminders,
            ReadQuestionnaire,
            ReadContent,
            RateContent,
            ReadDocument,
            ReadKeywords,
            WriteStatistics
        );

        public static readonly AireScopes KeyUserScopes = new(
            Profile,
            ChatHistory,
            ChatBot,
            Questionnaire,
            Content,
            Reminders,
            Document,
            DemoGroups,
            ReadServices,
            AireHub,
            PasswordChange,
            Keywords,
            Statistics,
            AdminAccounts,
            AdminInstanceSettings,
            ExperimentalCustomPrompt
        );

        public static readonly AireScopes AllClientScopes = new(
            Profile,
            ChatHistory,
            Questionnaire,
            Content,
            Reminders,
            Document,
            ChatBot,
            DemoGroups,
            Services,
            AireHub,
            PasswordChange,
            Keywords,
            Statistics,
            AdminAccounts,
            AdminClients,
            AdminInstanceSettings,
            Experimental
        );

        public static readonly Dictionary<string, AireScopes> DefaultRoleScopes = new() {
            { AireRoles.User, UserScopes },
            { AireRoles.Admin, AdminScopes },
            { AireRoles.DemoAdmin, DemoAdminScopes },
            { AireRoles.DemoUser, DemoUserScopes },
            { AireRoles.KeyUser, KeyUserScopes }
        };

        public static readonly Dictionary<string, AireScopes> ScopeAliasDict = new() {
            { "admin", AdminScopes },
            { "chat", ChatBot },
            { "chat-history", ChatHistory },
            { "content", Content },
            { "demo-admin", DemoAdminScopes },
            { "demo-groups", DemoGroups },
            { "document", Document },
            { "reminders", Reminders },
            { "keywords", Keywords },
            { "profile", Profile },
            { "questionnaire", Questionnaire },
            { "services", Services },
            { "statistics", Statistics }
        };

        public AireScopes() : base() { }
        public AireScopes(params dynamic[] collection) : base()
        {
            foreach (var item in collection)
            {
                if (item is string)
                    if (ScopeAliasDict != null && ScopeAliasDict.ContainsKey(item))
                        AddRange(ScopeAliasDict?[item]);
                    else
                        Add(item);
                else if (item is AireScopes)
                    AddRange(item);
                else
                    throw new ArgumentException("Unsupported argument");
            }
        }
    }
}
