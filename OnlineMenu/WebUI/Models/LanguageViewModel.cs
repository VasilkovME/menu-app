using System.Runtime.Serialization;

namespace WebUI.Models
{
    [DataContract]
    public class LanguageViewModel
    {
        [DataMember(Name = "cultureName")]
        public string CultureName { get; set; }
        [DataMember(Name = "languageName")]
        public string LanguageName { get; set; }
    }
}