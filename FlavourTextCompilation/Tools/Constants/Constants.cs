using Tools.Helpers;
using Tools.Models;

namespace Tools.Constants
{
    public class Constants
    {
        public readonly Dictionary<string, Type> FileNameDictionary = new Dictionary<string, Type>
        {
            { "ancestorequipmentdata.json", typeof(AncestorEquipment) },
            { "ancestornpcdialogue.json", typeof(AncestorNPCDialogue) },
            { "areadata.json", typeof(Area) },
            { "divinationcarddata.json", typeof(DivinationCard) },
            { "heistobjectivedata.json", typeof(HeistObjective) },
            { "keystonedata.json", typeof(KeyStone) },
            { "mapfragmentdata.json", typeof(MapFragment) },
            { "npctextaudiomarch2023.json", typeof(NPCDialogue) },
            { "prophecydata.json", typeof(Prophecy) },
            { "questitemdata.json", typeof(QuestItem) },
            { "uniqueitemdata.json", typeof(UniqueItem) },
            { "zodiac.json", typeof(Zodiac) }
        };
    }
}
