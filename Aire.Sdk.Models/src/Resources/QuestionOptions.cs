using Newtonsoft.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Aire.Sdk.Models.Resources
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuestionOptionType
    {
        [EnumMember(Value = "range")]
        Range,

        [EnumMember(Value = "checkbox")]
        Checkbox,

        [EnumMember(Value = "open")]
        Open,

        [EnumMember(Value = "number")]
        Number
    }

    public class QuestionOption
    {
    }

    public class QuestionOptionRange : QuestionOption
    {
        [JsonProperty("min", Required = Required.Always)]
        public int Min { get; set; }

        [JsonProperty("max", Required = Required.Always)]
        public int Max { get; set; }
    }

    public class QuestionOptionCheckbox : QuestionOption
    {
        [JsonProperty("values", Required = Required.Always)]
        public List<string>? Values { get; set; }

        [JsonProperty("multiselect")]
        public bool Multiselect { get; set; } = true;

        [JsonProperty("red_flag")]
        public string? RedFlag { get; set; }
    }

    public class QuestionOptionOpen : QuestionOption
    {
        [JsonProperty("max_len")]
        public int? MaxLen { get; set; }

        [JsonProperty("match")]
        public string? Match { get; set; }

        [JsonProperty("multiline")]
        public bool Multiline { get; set; } = false;
    }

    public class QuestionOptionNumber : QuestionOption
    {
        [JsonProperty("min")]
        public int? Min { get; set; }

        [JsonProperty("max")]
        public int? Max { get; set; }

        [JsonProperty("default")]
        public int? Default { get; set; }
    }
}
