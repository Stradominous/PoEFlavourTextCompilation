using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Tools.Enums;
using Tools.Helpers;
using LocalConstants = Tools.Constants.Constants;

class Program
{
    private static readonly LocalConstants constants = new LocalConstants();
    
    static void Main()
    {
        var allFilesExist = false;

        var userFileNames = GetUserFileNamesInput();

        userFileNames = userFileNames
                .Select(userFileName => String.Concat(userFileName.Where(character => !Char.IsWhiteSpace(character))))
                .ToList();

        allFilesExist = VerifyFileNamesExist(userFileNames);

        while (!allFilesExist)
        {
            Retry();

            userFileNames = GetUserFileNamesInput();

            userFileNames = userFileNames
                .Select(userFileName => String.Concat(userFileName.Where(character => !Char.IsWhiteSpace(character))))
                .ToList();

            allFilesExist = VerifyFileNamesExist(userFileNames);
        }

        Zodiac flavourTextJsonObject = ParseZodiacJsonFile();

        List<string> searchWords = GetUserSearchInput();

        bool searchUniqueItemModifiers = false;

        if(userFileNames.Contains(FileNameEnum.UniqueItemData.ToLower()) || userFileNames.Contains(FileNameEnum.Zodiac.ToLower()))
        {
            searchUniqueItemModifiers = GetUserUniqueItemModifiers();
        }

        bool searchWholeWords = GetUserWholeWordsInput();
        bool matchAllWords = false;

        if (searchWords.Count() > 1)
        {
            matchAllWords = GetUserMatchAllWordsInput();
        }

        List<FlavourTextJSON> jsonFlavourTextsMatched;

        SearchOptions searchOptions = new SearchOptions
        {
            MatchWholeWords = searchWholeWords,
            SearchUniqueItemModifiers = searchUniqueItemModifiers
        };

        if (matchAllWords)
        {
            jsonFlavourTextsMatched = flavourTextJsonObject.ContainsAllStrings(
                searchWords,
                userFileNames,
                searchOptions
            );
        }
        else
        {
            jsonFlavourTextsMatched = flavourTextJsonObject.ContainsAnyString(
                searchWords,
                userFileNames,
                searchOptions
            );
        }

        var jsonFiltered = JsonConvert.SerializeObject(jsonFlavourTextsMatched);

        var outputPath = $@"..\..\..\Output\filteredOutput_{string.Join("_", searchWords.Take(4))}_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}.json";
        File.WriteAllText(outputPath, jsonFiltered);
    }

    static bool GetUserUniqueItemModifiers()
    {
        Console.WriteLine("Do you want to search unique item modifiers?");
        Console.WriteLine("y = yes, n = no");
        Console.Write("> ");

        var searchUniqueMods = Console.ReadLine();

        return searchUniqueMods.ToLower() == "y" || searchUniqueMods.ToLower() == "yes";
    }

    static List<string> GetUserFileNamesInput()
    {
        Console.WriteLine("Available Files: ");

        // I know there's a better way to do this but I don't really care.
        Console.WriteLine("    " + FileNameEnum.Zodiac.ToLower());
        Console.WriteLine("    " + FileNameEnum.UniqueItemData.ToLower());
        Console.WriteLine("    " + FileNameEnum.QuestItemData.ToLower());
        Console.WriteLine("    " + FileNameEnum.ProphecyData.ToLower());
        Console.WriteLine("    " + FileNameEnum.NPCTextAudioMarch2023.ToLower());
        Console.WriteLine("    " + FileNameEnum.MapFragmentData.ToLower());
        Console.WriteLine("    " + FileNameEnum.KeyStoneData.ToLower());
        Console.WriteLine("    " + FileNameEnum.HeistObjectiveData.ToLower());
        Console.WriteLine("    " + FileNameEnum.UniqueItemData.ToLower());
        Console.WriteLine("    " + FileNameEnum.DivinationCardData.ToLower());
        Console.WriteLine("    " + FileNameEnum.AreaData.ToLower());
        Console.WriteLine("    " + FileNameEnum.AncestorNPCDialogue.ToLower());
        Console.WriteLine("    " + FileNameEnum.AncestorEquipment.ToLower());
        Console.WriteLine();
        Console.WriteLine("Which file(s) would you like to search?");
        Console.WriteLine("If you want to search using multiple files, use a comma between them.");
        Console.Write("> ");

        return Console.ReadLine().Split(',').ToList();
    }

    static List<string> GetUserSearchInput()
    {
        Console.WriteLine();
        Console.WriteLine("What words or phrases would you like to search with?");
        Console.WriteLine("If you want to search using multiple words or phrases, use a comma between them.");
        Console.Write("> ");
        
        var searchWords = Console.ReadLine()
            .Split(',')
            .Select(searchWord => searchWord.Trim())
            .ToList();

        return searchWords;
    }

    static bool GetUserWholeWordsInput()
    {
        Console.WriteLine("Would you like to match whole words only?");
        Console.WriteLine("y = yes, n = no");

        Console.Write("> ");

        var searchWholeWords = Console.ReadLine();

        return searchWholeWords.ToLower() == "y" || searchWholeWords.ToLower() == "yes";
    }

    static bool GetUserMatchAllWordsInput()
    {
        Console.WriteLine("Would you like to find texts that contain all words?");
        Console.WriteLine("y = yes, n = no");

        Console.Write("> ");

        var matchAllWords = Console.ReadLine();

        return matchAllWords.ToLower() == "y" || matchAllWords.ToLower() == "yes";
    }

    static bool VerifyFileNamesExist(List<string> userFileNamesInput)
    {
        // Grab files from solution items directory
        var listOfFileNamesAvailable = Directory
            .GetFiles(@"..\..\..\..\")
            .Select(file =>
                file.Replace(@"\", "")
                    .Remove(0, 8)) // Remove first 8 characters because they are all '.' characters, file name will still end with '.json'
            .ToList();

        foreach(var userFileNameInput in userFileNamesInput)
        {
            var foundFile = listOfFileNamesAvailable
                .Find(file => file.ToLower().StartsWith(userFileNameInput.ToLower()));

            if(foundFile == null)
            {
                return false;
            }
        }

        return true;
    }

    static Zodiac ParseZodiacJsonFile()
    {
        JObject jsonObject = JObject.Parse(File.ReadAllText(@"..\..\..\..\Zodiac.json"));

        var objectString = jsonObject.First.First().ToString(Formatting.None);

        return JsonConvert.DeserializeObject<Zodiac>(objectString);
    }

    static void Retry()
    {
        Console.WriteLine("Sorry, one of those files do not exist!");
        Console.WriteLine("Please press Enter to retry");
        Console.ReadLine();
        Console.Clear();
    }
}