// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.


namespace Aire.Sdk.Auth;

public class AireRoles : List<string>
{
    public const string NonMember = "non-member";
    public const string User = "user";
    public const string Admin = "admin";
    public const string DemoAdmin = "demo-admin";
    public const string DemoUser = "demo-user";
    public const string KeyUser = "key-user";
    public const string TrialUser = "trial-user";

    public static readonly AireRoles All = [NonMember, User, Admin, DemoAdmin, DemoUser, KeyUser, TrialUser];

    public AireRoles() : base() { }
    public AireRoles(params string[] roles) : base(roles) { }
    public AireRoles(params AireRoles[] roles)
    {
        foreach (var list in roles)
            AddRange(list);
    }

}
