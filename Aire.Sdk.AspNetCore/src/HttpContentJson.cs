using System.Net.Mime;
using System.Text;
using Aire.Sdk.Helpers;

namespace Aire.Sdk.AspNetCore;

public class JsonContent<T> : StringContent 
{
    public JsonContent(T obj) 
        : base(obj.ObjectToJson(), Encoding.UTF8, MediaTypeNames.Application.Json)
    { }
}
