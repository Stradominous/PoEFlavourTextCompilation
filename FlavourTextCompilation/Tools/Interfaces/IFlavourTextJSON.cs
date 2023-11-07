using Tools.Helpers;

namespace Tools.Interfaces
{
    public interface IFlavourTextJSON
    {
        public bool ContainsAnyString(List<string> searchStrings, SearchOptions searchOptions);
        public bool ContainsAllStrings(List<string> searchStrings, SearchOptions searchOptions);
        public bool FoundWord(string searchString, SearchOptions searchOptions);
    }
}
