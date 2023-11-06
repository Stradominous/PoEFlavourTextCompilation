using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Tools.Helpers;
using Tools.Interfaces;

namespace Tools.Models
{
    public class AncestorEquipment : FlavourTextJSON, IFlavourTextJSON
    {
        public string FileName { get => "AncestorEquipmentData.json"; }
        [JsonProperty(PropertyName = "Equipment")]
        public string Equipment { get; set; }
        [JsonProperty(PropertyName = "Tribe")]
        public string Tribe { get; set; }
        [JsonProperty(PropertyName = "Favour")]
        public string Favour { get; set; }
        [JsonProperty(PropertyName = "Effects")]
        public string Effects { get; set; }
        [JsonProperty(PropertyName = "Flavour Text")]
        public string FlavourText { get; set; }

        public override bool FoundWord(string searchString, SearchOptions searchOptions)
        {
            if (searchOptions.MatchWholeWords)
            {
                return
                (!String.IsNullOrEmpty(Equipment) && Regex.Match(Equipment, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(Tribe) && Regex.Match(Tribe, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(Favour) && Regex.Match(Favour, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(Effects) && Regex.Match(Effects, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(FlavourText) && Regex.Match(FlavourText, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success);
            }
            else
            {
                return
                (!String.IsNullOrEmpty(Equipment) && Equipment.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(Tribe) && Tribe.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(Favour) && Favour.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(Effects) && Effects.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(FlavourText) && FlavourText.ToLower().Contains(searchString.ToLower()));
            }
        }
    }
}
