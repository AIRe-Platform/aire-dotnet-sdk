namespace Aire.Sdk.Auth.Scopes
{
    public class AireScopes : List<string>
    {
        public const string ReadProfile = "profile-read";
        public const string EditProfile = "profile-edit";
        public const string DeleteProfile = "profile-delete";

        public static readonly AireScopes Profile = [ ReadProfile, EditProfile, DeleteProfile ];
        public static readonly AireScopes UserScopes = new AireScopes(Profile);
        public static readonly AireScopes All = new AireScopes(Profile);

        public AireScopes() : base() {}
        public AireScopes(params string[] scopes) : base(scopes) {}
        public AireScopes(params AireScopes[] scopes) 
        {
            foreach(var list in scopes)
                AddRange(list);
        }
    }
}
