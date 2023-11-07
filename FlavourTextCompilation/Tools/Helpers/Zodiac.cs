using Tools.Interfaces;
using Tools.Models;
using LocalConstants = Tools.Constants.Constants;

namespace Tools.Helpers
{
    public class Zodiac : FlavourTextJSON
    {
        private static readonly LocalConstants constants = new LocalConstants();
        public string FileName { get => "Zodiac.json"; }

        public List<UniqueItem> UniqueItems { get; set; }
        public List<QuestItem> QuestItems { get; set; }
        public List<HeistObjective> HeistObjectives { get; set; }
        public List<Prophecy> Prophecies { get; set; }
        public List<NPCDialogue> NPCTextAudioMarch2023 { get; set; }
        public List<MapFragment> MapFragments { get; set; }
        public List<KeyStone> Keystones { get; set; }
        public List<DivinationCard> DivinationCards { get; set; }
        public List<Area> Areas { get; set; }
        public List<AncestorNPCDialogue> AncestorNPCDialogue { get; set; }
        public List<AncestorEquipment> AncestorEquipment { get; set; }

        public List<FlavourTextJSON> ContainsAnyString(List<string> searchStrings, List<string> searchFiles, SearchOptions searchOptions)
        {
            List<Type> searchTypes = new List<Type>();

            searchFiles.ForEach(searchFile =>
            {
                searchTypes.Add(constants.FileNameDictionary[$"{searchFile}.json"]);
            });

            var zodiacFiltered = new Zodiac
            {
                UniqueItems = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(UniqueItem))
                    ? FilterContainsAnyString(
                        UniqueItems.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as UniqueItem).ToList()
                    : null,

                QuestItems = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(QuestItem))
                    ? FilterContainsAnyString(
                        QuestItems.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as QuestItem).ToList()
                    : null,

                HeistObjectives = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(HeistObjective))
                    ? FilterContainsAnyString(
                        HeistObjectives.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as HeistObjective).ToList()
                    : null,

                Prophecies = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(Prophecy))
                    ? FilterContainsAnyString(
                        Prophecies.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as Prophecy).ToList()
                    : null,

                NPCTextAudioMarch2023 = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(NPCDialogue))
                    ? FilterContainsAnyString(
                        NPCTextAudioMarch2023.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as NPCDialogue).ToList()
                    : null,

                MapFragments = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(MapFragment))
                    ? FilterContainsAnyString(
                        MapFragments.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as MapFragment).ToList()
                    : null,

                Keystones = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(KeyStone))
                    ? FilterContainsAnyString(
                        Keystones.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as KeyStone).ToList()
                    : null,

                DivinationCards = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(DivinationCard))
                    ? FilterContainsAnyString(
                        DivinationCards.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as DivinationCard).ToList()
                    : null,

                Areas = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(Area))
                    ? FilterContainsAnyString(
                        Areas.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as Area).ToList()
                    : null,

                AncestorNPCDialogue = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(AncestorNPCDialogue))
                    ? FilterContainsAnyString(
                        AncestorNPCDialogue.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as AncestorNPCDialogue).ToList()
                    : null,

                AncestorEquipment = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(AncestorEquipment))
                    ? FilterContainsAnyString(
                        AncestorEquipment.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as AncestorEquipment).ToList()
                    : null,
            };

            return new List<FlavourTextJSON> { zodiacFiltered };
        }
        public List<FlavourTextJSON> ContainsAllStrings(List<string> searchStrings, List<string> searchFiles, SearchOptions searchOptions)
        {
            List<Type> searchTypes = new List<Type>();

            searchFiles.ForEach(searchFile =>
            {
                searchTypes.Add(constants.FileNameDictionary[$"{searchFile}.json"]);
            });

            var zodiacFiltered = new Zodiac
            {
                UniqueItems = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(UniqueItem))
                    ? FilterContainsAllStrings(
                        UniqueItems.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as UniqueItem).ToList()
                    : null,

                QuestItems = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(QuestItem))
                    ? FilterContainsAllStrings(
                        QuestItems.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as QuestItem).ToList()
                    : null,

                HeistObjectives = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(HeistObjective))
                    ? FilterContainsAllStrings(
                        HeistObjectives.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as HeistObjective).ToList()
                    : null,

                Prophecies = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(Prophecy))
                    ? FilterContainsAllStrings(
                        Prophecies.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as Prophecy).ToList()
                    : null,

                NPCTextAudioMarch2023 = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(NPCDialogue))
                    ? FilterContainsAllStrings(
                        NPCTextAudioMarch2023.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as NPCDialogue).ToList()
                    : null,

                MapFragments = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(MapFragment))
                    ? FilterContainsAllStrings(
                        MapFragments.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as MapFragment).ToList()
                    : null,

                Keystones = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(KeyStone))
                    ? FilterContainsAllStrings(
                        Keystones.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as KeyStone).ToList()
                    : null,

                DivinationCards = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(DivinationCard))
                    ? FilterContainsAllStrings(
                        DivinationCards.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as DivinationCard).ToList()
                    : null,

                Areas = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(Area))
                    ? FilterContainsAllStrings(
                        Areas.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as Area).ToList()
                    : null,

                AncestorNPCDialogue = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(AncestorNPCDialogue))
                    ? FilterContainsAllStrings(
                        AncestorNPCDialogue.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as AncestorNPCDialogue).ToList()
                    : null,

                AncestorEquipment = searchTypes.Contains(typeof(Zodiac)) || searchTypes.Contains(typeof(AncestorEquipment))
                    ? FilterContainsAllStrings(
                        AncestorEquipment.Select(item => item as IFlavourTextJSON).ToList(),
                        searchStrings,
                        searchOptions).Select(item => item as AncestorEquipment).ToList()
                    : null,
            };

            return new List<FlavourTextJSON> { zodiacFiltered };
        }
    }
}
