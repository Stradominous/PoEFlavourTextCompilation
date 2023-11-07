using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Tools.Helpers;
using Tools.Interfaces;

namespace Tools.Models
{
    public class Prophecy : IFlavourTextJSON
    {
        public string FileName { get => "ProphecyData.json"; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Frame Type")]
        public string FrameType { get; set; }
        [JsonProperty(PropertyName = "Class")]
        public string Class { get; set; }
        [JsonProperty(PropertyName = "Is In Game")]
        public string IsInGame { get; set; }
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
                    || (!String.IsNullOrEmpty(FrameType) && Regex.Match(FrameType, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(Class) && Regex.Match(Class, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(FlavourText) && Regex.Match(FlavourText, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success);
            }
            else
            {
                return
                    (!String.IsNullOrEmpty(Name) && Name.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(FrameType) && FrameType.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(Class) && Class.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(FlavourText) && FlavourText.ToLower().Contains(searchString.ToLower()));
            }
        }
    }
}
