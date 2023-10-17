using System.Text.Json.Serialization;

namespace WebAPI_NET.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Collection
    {
       Eldraine = 1,
       Theros, 
       Ikoria, 
       CoreSet2021, 
       ZendikarRising,

    }
}