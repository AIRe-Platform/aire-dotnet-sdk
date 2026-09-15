// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


using System.Collections.ObjectModel;

namespace Aire.Sdk.Auth;

public class AireReadOnlyScopes(params dynamic[] collection)
    : ReadOnlyCollection<string>(new AireScopes(collection))
{
    public AireScopes GetMutableCopy()
    {
        return new AireScopes(this);
    }
}

public class AireScopes : List<string>
{
    public const string ReadProfile = "profile-read";
    public const string EditProfile = "profile-edit";
    public const string DeleteProfile = "profile-delete";
    public const string ConnectProfile = "profile-connect";
    public static readonly AireReadOnlyScopes Profile = new(ReadProfile, EditProfile, DeleteProfile, ConnectProfile);

    public const string ReadChatHistory = "chat-history-read";
    public const string WriteChatHistory = "chat-history-write";
    public const string DeleteChatHistory = "chat-history-delete";
    public static readonly AireReadOnlyScopes ChatHistory = new(ReadChatHistory, WriteChatHistory, DeleteChatHistory);

    public const string ReadQuestionnaire = "questionnaire-read";
    public const string WriteQuestionnaire = "questionnaire-write";
    public const string DeleteQuestionnaire = "questionnaire-delete";
    public static readonly AireReadOnlyScopes Questionnaire = new(ReadQuestionnaire, WriteQuestionnaire, DeleteQuestionnaire);

    public const string ReadPublicQuestionnaireResults = "pub-q-results-read";
    public const string DeletePublicQuestionnaireResults = "pub-q-results-delete";
    public static readonly AireReadOnlyScopes PublicQuestionnaireResults = new(ReadPublicQuestionnaireResults, DeletePublicQuestionnaireResults);

    public const string ReadContent = "content-read";
    public const string WriteContent = "content-write";
    public const string DeleteContent = "content-delete";
    public const string RateContent = "content-rate";
    public static readonly AireReadOnlyScopes Content = new(ReadContent, WriteContent, DeleteContent, RateContent);

    public const string ReadReminders = "reminder-read";
    public const string WriteReminders = "reminder-write";
    public const string DeleteReminders = "reminder-delete";
    public static readonly AireReadOnlyScopes Reminders = new(ReadReminders, WriteReminders, DeleteReminders);

    public const string ReadDocument = "document-read";
    public const string WriteDocument = "document-write";
    public const string DeleteDocument = "document-delete";
    public static readonly AireReadOnlyScopes Document = new(ReadDocument, WriteDocument, DeleteDocument);

    public const string ChatCompletion = "chat-completion";
    public const string ChatSummary = "chat-summary";
    public const string ChatTokenCount = "chat-token-count";
    public static readonly AireReadOnlyScopes ChatBot = new(ChatCompletion, ChatSummary, ChatTokenCount);

    public const string ReadDemoGroups = "demo-group-read";
    public const string EditDemoGroups = "demo-group-write";
    public const string DeleteDemoGroups = "demo-group-delete";
    public static readonly AireReadOnlyScopes DemoGroups = new(ReadDemoGroups, EditDemoGroups, DeleteDemoGroups);

    public const string ReadServices = "services-read";
    public const string EditServices = "services-edit";
    public const string DeleteServices = "services-delete";
    public static readonly AireReadOnlyScopes Services = new(ReadServices, EditServices, DeleteServices);

    public const string ReadKeywords = "keywords-read";
    public const string WriteKeywords = "keywords-write";
    public const string DeleteKeywords = "keywords-delete";
    public static readonly AireReadOnlyScopes Keywords = new(ReadKeywords, WriteKeywords, DeleteKeywords);

    public const string ReadStatistics = "statistics-read";
    public const string WriteStatistics = "statistics-write";
    public static readonly AireReadOnlyScopes Statistics = new(ReadStatistics, WriteStatistics);

    public const string ReadClients = "clients-read";
    public const string CreateClients = "clients-create";
    public const string EditClients = "clients-edit";
    public const string DeleteClients = "clients-delete";
    public static readonly AireReadOnlyScopes Clients = new(ReadClients, CreateClients, EditClients, DeleteClients);

    public const string ReadAccounts = "accounts-read";
    public const string EditAccounts = "accounts-edit";
    public static readonly AireReadOnlyScopes Accounts = new(ReadAccounts, EditAccounts);

    public const string AdminConfig = "admin-config";
    public const string AdminAgents = "admin-agents";
    public const string AdminInstanceSettings = "admin-instance-settings";
    public const string AdminModuleSettings = "admin-module-settings";
    public const string AdminInvites = "admin-invites";
    public const string AdminAudit = "admin-audit";

    public const string Auth = "auth";
    public const string AireHub = "aire-hub";
    public const string ListPlatforms = "list-platforms";
    public const string PasswordChange = "password-change";
    public const string TrialAccountUpgrade = "trial-account-upgrade";

    public const string FeatureTokenCount = "feat-token-count";
    public const string FeatureCustomPrompt = "feat-custom-prompt";

    public static readonly AireReadOnlyScopes AdminScopes = new(
        Profile,
        ChatHistory,
        ChatBot,
        Questionnaire,
        PublicQuestionnaireResults,
        Content,
        Reminders,
        Document,
        DemoGroups,
        Services,
        AireHub,
        ListPlatforms,
        PasswordChange,
        Keywords,
        Statistics,
        Accounts,
        Clients,
        AdminConfig,
        AdminAgents,
        AdminInstanceSettings,
        AdminModuleSettings,
        AdminInvites,
        AdminAudit,
        FeatureTokenCount,
        FeatureCustomPrompt
    );

    public static readonly AireReadOnlyScopes UserScopes = new(
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
        WriteStatistics,
        ListPlatforms
    );

    public static readonly AireReadOnlyScopes DemoAdminScopes = new(
        UserScopes,
        DemoGroups,
        FeatureTokenCount,
        FeatureCustomPrompt,
        AireHub,
        ListPlatforms
    );

    public static readonly AireReadOnlyScopes DemoUserScopes = new(
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
        WriteStatistics,
        ListPlatforms
    );

    public static readonly AireReadOnlyScopes KeyUserScopes = new(
        Profile,
        ChatHistory,
        ChatBot,
        Questionnaire,
        PublicQuestionnaireResults,
        Content,
        Reminders,
        Document,
        DemoGroups,
        ReadServices,
        AireHub,
        ListPlatforms,
        PasswordChange,
        Keywords,
        Statistics,
        ReadClients,
        AdminAgents,
        AdminInstanceSettings,
        AdminAudit,
        FeatureTokenCount,
        FeatureCustomPrompt
    );

    public static readonly AireReadOnlyScopes TrialUserScopes = new(
        ChatBot,
        ReadChatHistory,
        WriteChatHistory,
        ReadQuestionnaire,
        ReadProfile,
        ReadContent,
        RateContent,
        ReadDocument,
        ReadKeywords,
        WriteStatistics,
        TrialAccountUpgrade
    );

    public static readonly Dictionary<string, AireReadOnlyScopes> DefaultRoleScopes = new() {
        { AireRoles.NonMember, new(ListPlatforms)},
        { AireRoles.User, UserScopes },
        { AireRoles.Admin, AdminScopes },
        { AireRoles.DemoAdmin, DemoAdminScopes },
        { AireRoles.DemoUser, DemoUserScopes },
        { AireRoles.KeyUser, KeyUserScopes },
        { AireRoles.TrialUser, TrialUserScopes },
    };

    public static readonly Dictionary<string, AireReadOnlyScopes> ScopeAliasDict = new() {
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
        { "statistics", Statistics },
        { "admin-accounts", Accounts },
        { "accounts", Accounts },
        { "admin-clients", Clients },
        { "clients", Clients },
    };

    public static AireScopes ParseString(string scopes)
    {
        var result = new AireScopes();
        var arr = scopes.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        foreach (var scope in arr)
        {
            if (ScopeAliasDict != null && ScopeAliasDict.TryGetValue(scope, out var value))
                result.AddRange(value);
            else
                result.Add(scope);
        }
        return result;
    }

    public override string ToString()
    {
        return string.Join(' ', this);
    }

    public AireScopes() : base() { }
    public AireScopes(params dynamic[] collection) : base()
    {
        foreach (var item in collection)
        {
            if (item is string str)
                AddRange(ParseString(str));
            else if (item is IEnumerable<string> arr)
                foreach (var scope in arr)
                    AddRange(ParseString(scope));
            else
                throw new ArgumentException("Unsupported argument");
        }
    }
}

