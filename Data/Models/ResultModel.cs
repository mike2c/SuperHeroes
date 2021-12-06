using System.Runtime.Serialization;

namespace Data.Models
{
    [DataContract]
    public class ResultModel
    {
        [DataMember]
        public string Response { get; set; }
        [DataMember]
        public string Error { get; set; }
    }
}
