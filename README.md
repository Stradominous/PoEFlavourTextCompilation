## Introduction
<>< Welcome to the PoE flavour text compilation! ><>

A lot of this data was created through poewiki CargoTable queries.
You can read more on that here: https://www.poewiki.net/wiki/Path_of_Exile_Wiki:Data_query_API

You can also find the queries in: https://github.com/Stradominous/PoEFlavourTextCompilation/blob/main/Flavour%20Text%20Compilation/PoE%20Wiki%20Queries.txt

## Information
Here is the data that was fully gathered using the queries:
* Unique Items
* Passives (Atlas and Skill Tree)
* Areas
* Quest Items (Including Heist)
* Prophecies
* Divination Cards
* Map Fragments

Here is the data that was made by formatting existing data into JSON:
* Ancestor NPC Dialogues
* NPC Text Audio March 2023
* Ancestor Equipment Data

Note: Prophecies and Divination Cards do not have Rewards. I am planning on adding those by hand in the near future.

You can find a full compilation of all the data in: https://github.com/Stradominous/PoEFlavourTextCompilation/blob/main/Flavour%20Text%20Compilation/Zodiac.json

## Questions / Concerns?
I am planning to keep this data up to date. Probably once a league whenever new dialogue / flavour text is released.

If you have any suggestions or change requests, please reach out to me on Discord. My username is: "stradominous"

## Zodiac Structure

```json
{
  "Zodiac": {
    "UniqueItems": [
      {
        "name": "",
        "release version": "",
        "flavour text": "",
        "drop enabled": "",
        "drop areas": null,
        "Mods": ""
      }
    ],
    "QuestItems": [
      {
        "name": "",
        "frame type": "",
        "is in game": "",
        "flavour text": ""
      }
    ],
    "Prophecies": [
      {
        "name": "",
        "frame type": "",
        "class": "",
        "is in game": "",
        "flavour text": ""
      }
    ],
    "NPCTextAudioMarch2023": [
      {
        "Id": "",
        "Text": ""
      }
    ],
    "MapFragments": [
      {
        "name": "",
        "frame type": "",
        "is in game": "",
        "flavour text": ""
      }
    ],
    "Keystones": [
      {
        "name": "",
        "stat text": "",
        "flavour text": ""
      }
    ],
    "DivinationCards": [
      {
        "name": "",
        "is in game": "",
        "flavour text": ""
      }
    ],
    "Areas": [
      {
        "name": "",
        "area type tags": "",
        "tags": "",
        "flavour text": ""
      }
    ],
    "AncestorNPCDialogue": [
      {
        "NPC": "",
        "Id": "",
        "Text": ""
      }
    ],
    "AncestorEquipment": [
      {
        "Equipment": "",
        "Tribe": "",
        "Favour": "",
        "Effects": "",
        "Flavour Text": ""
      }
    ]
  }
}
```
