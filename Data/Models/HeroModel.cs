using System.Runtime.Serialization;

namespace Data.Models
{
    [DataContract]
    public class HeroModel
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public PowerStats PowerStats { get; set; }
        [DataMember]
        public Biography Biography { get; set; }
        [DataMember]
        public Appearance Appearance { get; set; }
        [DataMember]
        public Work Work{ get; set; }
        [DataMember]
        public Connections Connections { get; set; }
        [DataMember]
        public Image Image { get; set; }

    }

    [DataContract]
    public class PowerStats
    {
        [DataMember]
        public string Intelligence { get; set; }
        [DataMember]
        public string Strength { get; set; }
        [DataMember]
        public string Speed { get; set; }
        [DataMember]
        public string Durability { get; set; }
        [DataMember]
        public string Power { get; set; }
        [DataMember]
        public string Combat { get; set; }
    }

    [DataContract]
    public class Biography
    {
        [DataMember(Name = "full-name")]
        public string FullName { get; set; }
        [DataMember(Name = "alter-egos")]
        public string AlterEgos { get; set; }
        [DataMember]
        public string[] Aliases { get; set; }
        [DataMember(Name = "place-of-birth")]
        public string PlaceOfBirth { get; set; }
        [DataMember(Name = "first-appearance")]
        public string FirstAppareance { get; set; }
        [DataMember]
        public string Publisher { get; set; }
        [DataMember]
        public string Alignment { get; set; }
    }

    [DataContract]
    public class Work
    {
        [DataMember]
        public string Ocupation { get; set; }
        [DataMember]
        public string Base { get; set; }
    }

    [DataContract]
    public class Connections
    {
        [DataMember(Name = "group-affiliation")]
        public string GroupAffiliation { get; set; }
        [DataMember]
        public string Relatives { get; set; }
    }

    [DataContract]
    public class Appearance
    {
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string Race { get; set; }
        [DataMember]
        public string[] Height { get; set; }
        [DataMember]
        public string[] Weight { get; set; }
        [DataMember(Name = "eye-color")]
        public string EyeColor { get; set; }
        [DataMember(Name = "hair-color")]
        public string HairColor { get; set; }
    }

    [DataContract]
    public class Image
    {
        [DataMember]
        public string Url { get; set; }
    }
}
