using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OpenApI_b3.Model
{
    [Serializable]
    public class Education
    {
        [DataMember]
        [JsonPropertyOrder(1)]
        public string Name { get; set; }
        [DataMember]
        [JsonPropertyOrder(2)]
        public string Institute { get; set; }
        [DataMember]
        [JsonPropertyOrder(3)]
        public string Degree { get; set; }
        [DataMember]
        [JsonPropertyOrder(4)]
        public string GPA { get; set; }
    }
}
