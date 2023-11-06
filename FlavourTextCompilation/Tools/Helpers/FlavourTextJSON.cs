using Tools.Interfaces;

namespace Tools.Helpers
{
    public abstract class FlavourTextJSON
    {
        public virtual List<FlavourTextJSON> ContainsAnyString(List<string> searchStrings, List<string> searchFiles, SearchOptions searchOptions)
        {
            foreach (var searchString in searchStrings)
            {
                if (FoundWord(searchString, searchOptions))
                {
                    return new List<FlavourTextJSON> { this };
                }
            };

            return new List<FlavourTextJSON>();
        }

        public virtual List<FlavourTextJSON> ContainsAllStrings(List<string> searchStrings, List<string> searchFiles, SearchOptions searchOptions)
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
                return new List<FlavourTextJSON> { this };
            }
            else
            {
                return new List<FlavourTextJSON>();
            }
        }

        public virtual List<IFlavourTextJSON> FilterContainsAnyString(List<IFlavourTextJSON> flavourTextJSONs, List<string> searchStrings, List<string> searchFiles, SearchOptions searchOptions)
        {
            List<IFlavourTextJSON> filteredList = new List<IFlavourTextJSON>();

            if (true) // searchFiles.Includes() or something
            {
                var x = flavourTextJSONs
                .Where(flavourTextJSON => flavourTextJSON.ContainsAnyString(searchStrings, searchFiles, searchOptions).Count() > 0)
                .ToList();

                filteredList.AddRange(x);
            }

            return filteredList;
        }

        public virtual List<IFlavourTextJSON> FilterContainsAllStrings(List<IFlavourTextJSON> flavourTextJSONs, List<string> searchStrings, List<string> searchFiles, SearchOptions searchOptions)
        {
            List<IFlavourTextJSON> filteredList = new List<IFlavourTextJSON>();

            if (true) // searchFiles.Includes() or something
            {
                var x = flavourTextJSONs
                .Where(flavourTextJSON => flavourTextJSON.ContainsAllStrings(searchStrings, searchFiles, searchOptions).Count() > 0)
                .ToList();

                filteredList.AddRange(x);
            }

            return filteredList;
        }

        public virtual bool FoundWord(string searchString, SearchOptions searchOptions)
        {
            throw new NotImplementedException();
        }
    }
}
