namespace Tools.Helpers
{
    public class SearchOptions
    {
        public bool MatchWholeWords { get; set; }
        public bool SearchUniqueItemModifiers { get; set; }

        /* TODO */
        public bool MatchCasing { get; set; }
        public bool GetWordCount { get; set; }
    }
}
