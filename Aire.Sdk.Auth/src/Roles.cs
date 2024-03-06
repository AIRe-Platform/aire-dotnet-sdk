namespace Aire.Sdk.Auth
{
    public class AireRoles : List<string>
    {
        public const string User = "user";
        public const string Admin = "admin";

        public const string Researcher = "researcher";
        public const string ResearchSubject = "research-subject";

        public static readonly AireRoles All = [ User, Admin, Researcher, ResearchSubject ];

        public AireRoles() : base() {}
        public AireRoles(params string[] roles) : base(roles) {}
        public AireRoles(params AireRoles[] roles) 
        {
            foreach(var list in roles)
                AddRange(list);
        }

    }
}
