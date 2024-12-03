using System;
using System.Collections.Generic;

namespace CharacterCreationSystem
{
    public class Dictionaries
    {
        // character information
        public static Dictionary<int, Element> MoonCycles { get; set; } = [];
        public static Dictionary<int, Element> Forms { get; set; } = [];
        public static Dictionary<int, Element> PirateCodes { get; set; } = [];

        // character weapons          
        public static Dictionary<int, Element> MainWeapons { get; set; } = [];
        public static Dictionary<int, Element> SecondarySkills { get; set; } = [];
        public static Dictionary<int, Element> NatureSkills { get; set; } = [];
        public static Dictionary<int, Element> AdditionalSkills { get; set; } = [];

        // character traits
        public static Dictionary<int, Element> PhysicalTrademarks { get; set; } = [];
        public static Dictionary<int, Element> SkinTones { get; set; } = [];
        public static Dictionary<int, Element> HairStyles { get; set; } = [];
        public static Dictionary<int, Element> FacialHairs { get; set; } = [];
        public static Dictionary<int, Element> BaseClothings { get; set; } = [];
        public static Dictionary<int, Element> Accessories { get; set; } = [];
        public static Dictionary<int, Element> PirateOrigins { get; set; } = [];
        public static Dictionary<int, Element> ShipTypes { get; set; } = [];
        public static Dictionary<int, Element> ShipSizes { get; set; } = [];
        public static Dictionary<int, Element> Pets { get; set; } = [];
        public static Dictionary<int, Element> Crews { get; set; } = [];
        public static Dictionary<int, Element> Triggers { get; set; } = [];
        public static Dictionary<int, Element> Debuffs { get; set; } = [];

        // Character Information Array
        public static Dictionary<int, Element>[] PirateDictionaries = new Dictionary<int, Element>[] {
            null,
            MoonCycles,
            Forms,
            PirateCodes
        };

        // Character Traits Array
        public static Dictionary<int, Element>[] TraitsDictionaries = new Dictionary<int, Element>[] {
            PhysicalTrademarks,
            SkinTones,
            HairStyles,
            FacialHairs,
            BaseClothings,
            Accessories,
            PirateOrigins,
            ShipTypes,
            ShipSizes,
            Pets,
            Crews,
            Triggers,
            Debuffs
        };

        // Character Weapons Array
        public static Dictionary<int, Element>[] CharacterWeapons = new Dictionary<int, Element>[]
        {
            MainWeapons,
            SecondarySkills,
            NatureSkills,
            AdditionalSkills
        };

        // Character Information Title and Questions
        public static object[,] CharacterInfoTitles = new object[,]
        {
            {"Name", null, "What will be the name of your pirate? (Maximum of 20 ALPHANUMER CHARACTER ONLY)" },
            {"Moon Cycle", MoonCycles,  "How old in terms of moon cycle will your character be?" },
            {"Form", Forms, "How do you want your pirate to be seen?" },
            {"Pirate Code", PirateCodes, "Does your pirate follow the Code?" }
        };

        // Character Weapons Title and Questions
        public static object[,] CharacterWeaponsTitles = new object[,]
        {
            {"Main Weapon", MainWeapons, "What will be your main handheld weapon?" },
            {"Secondary Skill", SecondarySkills, "What will be your secondary magical skill" },
            {"Nature Skill", NatureSkills, "What will be your nature skill?" },
            {"Additional Skill", AdditionalSkills, "What additional skill do you want to use?" }
        };

        // Character Traits Title and Questions
        public static object[,] CharacterTraitTitles = new object[,]
        {
            {"Physical Trademark",PhysicalTrademarks, "What trademark should your pirate have?" },
            {"Skin Tone", SkinTones, "What skin tone should your pirate have?" },
            {"Hair Style", HairStyles, "What about their hair style?" },
            {"Facial Hair", FacialHairs, "Next, facial hair?" },
            {"Base Clothing", BaseClothings, "What about their clothing?" },
            {"Accessories", Accessories, "Any accessories?" },
            {"Pirate Origin", PirateOrigins, "Where did you came from?" },
            {"Ship Type", ShipTypes, "What ship are you going to use?" },
            {"Ship Size", ShipSizes, "What size will be your ship?" },
            {"Pet", Pets, "What kind of pet do you want to accompany you?" },
            {"Crew", Crews, "Who will be your pirate buddies in this adventure?" },
            {"Trigger", Triggers, "What debuff trigger do you want to control?" },
            {"Debuff", Debuffs, "What debuff can you take?" }
        };

        // Array of Element Information
        public static object[] dictionaries = new object[]
        {
            CharacterInfoTitles,
            CharacterWeaponsTitles,
            CharacterTraitTitles
        };       
        public static void CreateDataMaps()
        {
            try
            {
                // character information
                MoonCycles[1] = new Element("New Moon", "A young new pirate, a beginner sailor filled with potential and thirst to learn more.", 10, 0, 0, 0, 0);
                MoonCycles[2] = new Element("Waxing Sailor", "A prime pirate, one that has gained enough knowledge to traverse the open seas and dive into the deeper challenges of piracy.", 10, 0, 0, 0, 0);
                MoonCycles[3] = new Element("Full Tide", "A pirate in their peak era, one that has garnered sufficient experience, radiating immense command and authority over their crew.", 10, 0, 0, 0, 0);
                MoonCycles[4] = new Element("Waning Shadow", "A renowned pirate, respected not just by their crew but also by other pirate crews.", 10, 0, 0, 0, 0);
                MoonCycles[5] = new Element("Eclipsed Wander", "A legendary pirate, tested by all the great waves, having vast knowledge and experience of the seas.", 10, 0, 0, 0, 0);

                Forms[1] = new Element("Pixie", "Small and extremely agile.", 10, 0, 0, 0, 0);
                Forms[2] = new Element("Scout", "Lean and quick.", 10, 0, 0, 0, 0);
                Forms[3] = new Element("General", "Steady and average.", 10, 0, 0, 0, 0);
                Forms[4] = new Element("Goliath", "Gigantic and imposing.", 10, 0, 0, 0, 0);
                Forms[5] = new Element("Colossus", "Monumental and powerful.", 10, 0, 0, 0, 0);

                PirateCodes[1] = new Element("Yes", "Can only form allegiance with Pirate who follows the Code.", 0, 0, 0, 0, 0);
                PirateCodes[2] = new Element("No", "Can only form allegiance with Pirate who does not follow the Code.", 0, 0, 0, 0, 0);

                // character weapons 
                SecondarySkills[1] = new Element("Necromancy", "Pirate with the skill to resurrect the dead", 10, 0, 0, 0, 0);
                SecondarySkills[2] = new Element("Blood Magic", "Pirates with blood magic can control people to either heal or harm them using their blood.", 10, 0, 0, 0, 0);
                SecondarySkills[3] = new Element("Transmutation", "Pirates with this skill can transform various objects into other things.", 10, 0, 0, 0, 0);
                SecondarySkills[4] = new Element("Alchemy", "These are pirates that are gifted with the knowledge of potion and luck.", 10, 0, 0, 0, 0);
                SecondarySkills[5] = new Element("Teleportation", "These are pirates who are given the ability to teleport to various locations.", 10, 0, 0, 0, 0);

                MainWeapons[1] = new Element("Bow and Arrow", "Long-ranged weapon; deals damage from a distance. ", 10, 0, 0, 0, 0);
                MainWeapons[2] = new Element("Harpoon", "Melee weapon; used for grappling and dealing damage.", 10, 0, 0, 0, 0);
                MainWeapons[3] = new Element("Gun", "Ranged weapon; used for powerful and distant damage.", 10, 0, 0, 0, 0);
                MainWeapons[4] = new Element("Sword", "Melee weapon; used for close-range combat.", 10, 0, 0, 0, 0);
                MainWeapons[5] = new Element("Dagger", "Melee weapon; used for quick attacks and stealth.", 10, 0, 0, 0, 0);

                NatureSkills[1] = new Element("Lightning Manipulation", "Provides an ability to control lighting.", 10, 0, 0, 0, 0);
                NatureSkills[2] = new Element("Sea Control", "Provides the pirate control over the sea and its waters.", 10, 0, 0, 0, 0);
                NatureSkills[3] = new Element("Wind Redirection", "Enables the pirate to redirect wind.", 10, 0, 0, 0, 0);
                NatureSkills[4] = new Element("Animal Summoning", "Allows the pirate to summon any animal.", 10, 0, 0, 0, 0);
                NatureSkills[5] = new Element("Stormcalling", "Gives a pirate the ability to create storms.", 10, 0, 0, 0, 0);

                AdditionalSkills[1] = new Element("Sailing", "Skill to navigate and control ships.", 10, 0, 0, 0, 0);
                AdditionalSkills[2] = new Element("Lockpicking", "Skills to open locked chests or doors.", 10, 0, 0, 0, 0);
                AdditionalSkills[3] = new Element("Alchemy", "Skills to create potions.", 10, 0, 0, 0, 0);
                AdditionalSkills[4] = new Element("Cartography", "Skills to access and read maps.", 10, 0, 0, 0, 0);
                AdditionalSkills[5] = new Element("Underwater Combat", "Skill to fight underwater.", 10, 0, 0, 0, 0);

                // character traits
                PhysicalTrademarks[1] = new Element("Missing an eye", "", 10, 0, 0, 0, 0);
                PhysicalTrademarks[2] = new Element("Missing a leg", "", 10, 0, 0, 0, 0);
                PhysicalTrademarks[3] = new Element("Missing an arm", "", 10, 0, 0, 0, 0);
                PhysicalTrademarks[4] = new Element("Tattooed face", "", 10, 0, 0, 0, 0);
                PhysicalTrademarks[5] = new Element("Golden teeth", "", 10, 0, 0, 0, 0);

                SkinTones[1] = new Element("Pale", "", 10, 0, 0, 0, 0);
                SkinTones[2] = new Element("Tanned", "", 10, 0, 0, 0, 0);
                SkinTones[3] = new Element("Dark", "", 10, 0, 0, 0, 0);
                SkinTones[4] = new Element("White", "", 10, 0, 0, 0, 0);
                SkinTones[5] = new Element("Light Brown", "", 10, 0, 0, 0, 0);

                HairStyles[1] = new Element("Long", "", 10, 0, 0, 0, 0);
                HairStyles[2] = new Element("Short", "", 10, 0, 0, 0, 0);
                HairStyles[3] = new Element("Braided", "", 10, 0, 0, 0, 0);
                HairStyles[4] = new Element("Dreadlocks", "", 10, 0, 0, 0, 0);
                HairStyles[5] = new Element("Bald", "", 10, 0, 0, 0, 0);

                FacialHairs[1] = new Element("Beard", "", 10, 0, 0, 0, 0);
                FacialHairs[2] = new Element("Mustache", "", 10, 0, 0, 0, 0);
                FacialHairs[3] = new Element("Goatee", "", 10, 0, 0, 0, 0);
                FacialHairs[4] = new Element("Combined beard & mustache", "", 10, 0, 0, 0, 0);
                FacialHairs[5] = new Element("No facial hair", "", 10, 0, 0, 0, 0);

                BaseClothings[1] = new Element("Linen", "", 10, 0, 0, 0, 0);
                BaseClothings[2] = new Element("Canvas", "", 10, 0, 0, 0, 0);
                BaseClothings[3] = new Element("Cotton", "", 10, 0, 0, 0, 0);
                BaseClothings[4] = new Element("Wool", "", 10, 0, 0, 0, 0);
                BaseClothings[5] = new Element("Leather", "", 10, 0, 0, 0, 0);

                Accessories[1] = new Element("Belt", "", 10, 0, 0, 0, 0);
                Accessories[2] = new Element("Necklace", "", 10, 0, 0, 0, 0);
                Accessories[3] = new Element("Bracelets", "", 10, 0, 0, 0, 0);
                Accessories[4] = new Element("Rings", "", 10, 0, 0, 0, 0);
                Accessories[5] = new Element("Earrings", "", 10, 0, 0, 0, 0);

                PirateOrigins[1] = new Element("North Sea", "Character from the seas of Legendary Mistheim and the icy shores of Skadi’s islands.", 10, 0, 0, 0, 0);
                PirateOrigins[2] = new Element("South Sea", "Characters from the southern Island of Eristia and the Ancient Ruins of the Sunken Kingdom.", 10, 0, 0, 0, 0);
                PirateOrigins[3] = new Element("East Sea", "Characters from the Floating Island of Skull Realm hiding the Temples of the Dragon Isles.", 10, 0, 0, 0, 0);
                PirateOrigins[4] = new Element("West Sea", "Characters from the Mystical Island of Siren’s Song near the legendary city of Atlantis.", 10, 0, 0, 0, 0);
                PirateOrigins[5] = new Element("Mid Sea", "Characters from the storm-ridden isles of the Temptes and the Frozen Icefjord.", 10, 0, 0, 0, 0);

                ShipTypes[1] = new Element("Galleon", "Large, multi-decked ship, ideal for long voyages and naval battles.", 10, 0, 0, 0, 0);
                ShipTypes[2] = new Element("Frigate", "Fast, maneuverable warship, ideal for trading and scouting.", 10, 0, 0, 0, 0);
                ShipTypes[3] = new Element("Sloop", "Small nimble ship, ideal for stealth and quick attacks.", 10, 0, 0, 0, 0);
                ShipTypes[4] = new Element("Xebec", "Fast, maneuverable ship, ideal for piracy and trade.", 10, 0, 0, 0, 0);
                ShipTypes[5] = new Element("Brigantine", "Versatile ship, Combining speed and firepower.", 10, 0, 0, 0, 0);

                ShipSizes[1] = new Element("Beginner", "Tiny, easy to handle ship, suitable for new players.", 10, 0, 0, 0, 0);
                ShipSizes[2] = new Element("Small", "Small, maneuverable ship, ideal for quick attacks and escape.", 10, 0, 0, 0, 0);
                ShipSizes[3] = new Element("Medium", "Balanced ship, offering a good mix of speed, firepower, and cargo capacity.", 10, 0, 0, 0, 0);
                ShipSizes[4] = new Element("Large", "Powerful, heavily armed ship, ideal for naval battles and exploration.", 10, 0, 0, 0, 0);
                ShipSizes[5] = new Element("Gigantic", "Massive, heavily armored ship, ideal for dominating the seas.", 10, 0, 0, 0, 0);

                Pets[1] = new Element("Parrot", "Colorful bird, good talker, helps with scouting.", 10, 0, 0, 0, 0);
                Pets[2] = new Element("Crow", "Intelligent bird good at finding treasure and scavenging.", 10, 0, 0, 0, 0);
                Pets[3] = new Element("Shark", "Fearsome predators, guards treasure, and attacks enemies.", 10, 0, 0, 0, 0);
                Pets[4] = new Element("Monkey", "Agile climber, good at stealing and distracting enemies.", 10, 0, 0, 0, 0);
                Pets[5] = new Element("Dog", "Loyal companion, good at tracking and guarding.", 10, 0, 0, 0, 0);

                Crews[1] = new Element("Gunners", "Skilled in using firearms, ideal for naval battles.", 10, 0, 0, 0, 0);
                Crews[2] = new Element("Swordsmen", "Skilled in using swords, ideal for close-quarters combats.", 10, 0, 0, 0, 0);
                Crews[3] = new Element("Rogues", "Skilled in stealth and trickery, ideal for infiltration and sabotage.", 10, 0, 0, 0, 0);
                Crews[4] = new Element("Navigators", "Skilled in navigating the seas, ideal for exploration and trade.", 10, 0, 0, 0, 0);
                Crews[5] = new Element("Shipwrights", "Skilled in building and repairing ships, ideal for maintaining the fleet.", 10, 0, 0, 0, 0);

                Triggers[1] = new Element("Night Blindness", "The character suffers reduced visibility in lowlight conditions.", 10, 0, 0, 0, 0);
                Triggers[2] = new Element("Cursed Weapon", "A powerful weapon with a negative side effect.", 10, 0, 0, 0, 0);
                Triggers[3] = new Element("Weakened", "The character suffers reduced physical and mental abilities.", 10, 0, 0, 0, 0);
                Triggers[4] = new Element("Poisoned", "The characters suffer from a harmful toxin.", 10, 0, 0, 0, 0);
                Triggers[5] = new Element("Bad luck", "The character suffers from misfortune and poor luck.", 10, 0, 0, 0, 0);

                Debuffs[1] = new Element("Night Blindness", "The character suffers reduced visibility in lowlight conditions.", 10, 0, 0, 0, 0);
                Debuffs[2] = new Element("Cursed Weapon", "A powerful weapon with a negative side effect.", 10, 0, 0, 0, 0);
                Debuffs[3] = new Element("Weakened", "The character suffers reduced physical and mental abilities.", 10, 0, 0, 0, 0);
                Debuffs[4] = new Element("Poisoned", "The characters suffer from a harmful toxin.", 10, 0, 0, 0, 0);
                Debuffs[5] = new Element("Bad luck", "The character suffers from misfortune and poor luck.", 10, 0, 0, 0, 0);
            } 
            catch (Exception e)
            {
                Console.WriteLine("Error in Data Maps Creation! " + e.Message);
            }
        }	
	}
}
