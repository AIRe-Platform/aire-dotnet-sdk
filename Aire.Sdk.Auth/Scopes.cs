namespace Aire.Sdk.Auth.Scopes
{
    public static class AireScopes
    {
        public const string ReadProfile = "profile-read";
        public const string EditProfile = "profile-edit";
        public const string DeleteProfile = "profile-delete";

        public static readonly string[] Profile = [ ReadProfile, EditProfile, DeleteProfile ];
    }
}
