using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data.Models
{
    [DataContract]
    public class SearchResultModel : ResultModel
    {
        public SearchResultModel()
        {
            Results = new List<HeroModel>();
        }
               
        [DataMember]
        public string ResultFor { get; set; }
        [DataMember]
        public ICollection<HeroModel> Results { get; set; }
    }
}
