using System.Text.Json.Serialization;

namespace Facebook_Api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Reaction
    {
        Angry=0,
        Cry=1,
        Care=2, 
        Love=3, 
        Laugh=4
    }
}
