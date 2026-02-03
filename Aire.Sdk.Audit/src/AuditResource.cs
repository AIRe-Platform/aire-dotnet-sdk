// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace Aire.Sdk.Audit;

public class AireAuditResource
{
    public string Type { get; set; }
    public string Id { get; set; }

    public const string InviteCodeResourceType = "invite-code";

    public AireAuditResource(string type, string? id = null)
    {
        id ??= "";

        if (!ValidResourceString(type))
            throw new ArgumentException("Invalid resource string", nameof(type));

        if (!ValidResourceString(id))
            throw new ArgumentException("Invalid resource string", nameof(id));

        Type = type;
        Id = id;
    }

    public static bool ValidResourceString(string s)
    {
        char[] separators = ['.', '-', '_'];
        return !s.Any(c => !char.IsAsciiLetterOrDigit(c) && !separators.Contains(c));
    }

    public override string ToString()
    {
        return $"{Type}:{Id.Trim() ?? ""}";
    }

    public string CreateFilter(string key)
    {
        string resource = ToString();
        if (string.IsNullOrWhiteSpace(Id))
        {
            char last = (char)(resource.Last() + 1);
            string end = resource[..^1] + last;
            return $"{key} ge '{resource}' and {key} lt '{end}'";
        }
        else
        {
            return $"{key} eq '{resource}'";
        }
    }

    public static AireAuditResource? Parse(string? s)
    {
        if (s != null)
        {
            var parts = s.Split(':', StringSplitOptions.TrimEntries);
            if (parts.Length == 2)
                return new AireAuditResource(parts[0], parts[1]);
        }
        return null;
    }
}
