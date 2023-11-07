using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Tools.Helpers;
using Tools.Interfaces;

namespace Tools.Models
{
    public class AncestorNPCDialogue : IFlavourTextJSON
    {
        public string FileName { get => "AncestorNPCDialogue.json"; }
        [JsonProperty(PropertyName = "NPC")]
        public string NPC { get; set; }
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }

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
                (!String.IsNullOrEmpty(NPC) && Regex.Match(NPC, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(Id) && Regex.Match(Id, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(Text) && Regex.Match(Text, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success);
            }
            else
            {
                return
                (!String.IsNullOrEmpty(NPC) && NPC.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(Id) && Id.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(Text) && Text.ToLower().Contains(searchString.ToLower()));
            }
        }
    }
}
