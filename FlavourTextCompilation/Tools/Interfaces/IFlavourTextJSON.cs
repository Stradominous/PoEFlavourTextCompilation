using Tools.Helpers;

namespace Tools.Interfaces
{
    public interface IFlavourTextJSON
    {
        public List<FlavourTextJSON> ContainsAnyString(List<string> searchStrings, List<string> searchFiles, SearchOptions searchOptions);
        public List<FlavourTextJSON> ContainsAllStrings(List<string> searchStrings, List<string> searchFiles, SearchOptions searchOptions);
    }
}
