using System.Text.Json.Serialization;

namespace FakeBookData.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FakerLocale
    {
        En,
        Nl,
        Ru
    }
}