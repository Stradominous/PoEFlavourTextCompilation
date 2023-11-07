using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Tools.Helpers;
using Tools.Interfaces;

namespace Tools.Models
{
    public class KeyStone : IFlavourTextJSON
    {
        public string FileName { get => "KeyStoneData.json"; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Stat Text")]
        public string StatText { get; set; }
        [JsonProperty(PropertyName = "Flavour Text")]
        public string FlavourText { get; set; }

        public bool ContainsAnyString(List<string> searchStrings, SearchOptions searchOptions)
        {
            foreach (var searchString in searchStrings)
            {
                if (FoundWord(searchString, searchOptions))
                {
                    return true;
                }
            };

            return false;
        }

        public bool ContainsAllStrings(List<string> searchStrings, SearchOptions searchOptions)
        {
            List<bool> foundStrings = new List<bool>();

            foreach (var searchString in searchStrings)
            {
                if (FoundWord(searchString, searchOptions))
                {
                    foundStrings.Add(true);
                }
            };

            if (foundStrings.Count() == searchStrings.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool FoundWord(string searchString, SearchOptions searchOptions)
        {
            if (searchOptions.MatchWholeWords)
            {
                return
                    (!String.IsNullOrEmpty(Name) && Regex.Match(Name, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(StatText) && Regex.Match(StatText, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(FlavourText) && Regex.Match(FlavourText, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success);
            }
            else
            {
                return
                    (!String.IsNullOrEmpty(Name) && Name.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(StatText) && StatText.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(FlavourText) && FlavourText.ToLower().Contains(searchString.ToLower()));
            }
        }
    }
}
