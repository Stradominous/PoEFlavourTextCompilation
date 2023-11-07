﻿using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Tools.Helpers;
using Tools.Interfaces;

namespace Tools.Models
{
    public class UniqueItem : IFlavourTextJSON
    {
        public string FileName { get => "UniqueItemData.json"; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "Release Version")]
        public string ReleaseVersion { get; set; }
        [JsonProperty(PropertyName = "Flavour Text")]
        public string FlavourText { get; set; }
        [JsonProperty(PropertyName = "Drop Enabled")]
        public string DropEnabled { get; set; }
        [JsonProperty(PropertyName = "Drop Areas")]
        public string DropAreas { get; set; }
        [JsonProperty(PropertyName = "Mods")]
        public string Mods { get; set; }

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
                    || (!String.IsNullOrEmpty(ReleaseVersion) && Regex.Match(ReleaseVersion, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(FlavourText) && Regex.Match(FlavourText, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(DropAreas) && Regex.Match(DropAreas, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success)
                    || (!String.IsNullOrEmpty(Mods) && searchOptions.SearchUniqueItemModifiers && Regex.Match(Mods, $@"\b{searchString}\b", RegexOptions.IgnoreCase).Success);
            }
            else
            {
                return
                    (!String.IsNullOrEmpty(Name) && Name.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(ReleaseVersion) && ReleaseVersion.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(FlavourText) && FlavourText.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(DropAreas) && DropAreas.ToLower().Contains(searchString.ToLower()))
                    || (!String.IsNullOrEmpty(Mods) && searchOptions.SearchUniqueItemModifiers && Mods.ToLower().Contains(searchString.ToLower()));
            }
        }
    }
}
