using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Tools.Helpers;
using Tools.Interfaces;

namespace Tools.Models
{
    public class AncestorNPCDialogue : FlavourTextJSON, IFlavourTextJSON
    {
        public string FileName { get => "AncestorNPCDialogue.json"; }
        [JsonProperty(PropertyName = "NPC")]
        public string NPC { get; set; }
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }

        public override bool FoundWord(string searchString, SearchOptions searchOptions)
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
