using System.Web;

namespace Aire.Sdk.AspNetCore;

public static class QueryString
{
    public static string FromDictionary(Dictionary<string, string?> kvp)
    {
        return "?" + string.Join("&", kvp.Select(x =>
        {
            var param = HttpUtility.UrlEncode(x.Key);
            if (x.Value != null)
                param += "=" + HttpUtility.UrlEncode(x.Value);
            return param;
        }));
    }
}
