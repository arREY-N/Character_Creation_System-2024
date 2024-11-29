using System;
using System.Collections.Generic;

namespace CharacterCreationSystem
{
    public class Dictionaries
    {
        
        public static Dictionary<int, string[]> MoonCycles { get; set; } = [];
        public static Dictionary<int, string[]> Forms { get; set; } = [];
        public static Dictionary<int, string[]> Types { get; set; } = [];
        public static Dictionary<int, string[]> PirateCodes { get; set; } = [];

        public static Dictionary<int, string[]>[] PirateDictionaries = new Dictionary<int, string[]>[] { 
            MoonCycles, 
            Forms, 
            Types, 
            PirateCodes };
        
        public static Dictionary<int, object[]> PhysicalTrademarks { get; set; } = [];
        public static Dictionary<int, object[]> SkinTones { get; set; } = [];
        public static Dictionary<int, object[]> HairStyles { get; set; } = [];
        public static Dictionary<int, object[]> FacialHairs { get; set; } = [];
        public static Dictionary<int, object[]> MainWeapons { get; set; } = [];
        public static Dictionary<int, object[]> NatureSkills { get; set; } = [];
        public static Dictionary<int, object[]> AdditionalSkills { get; set; } = [];
        public static Dictionary<int, object[]> BaseClothings { get; set; } = [];
        public static Dictionary<int, object[]> Accessories { get; set; } = [];
        public static Dictionary<int, object[]> PirateOrigins { get; set; } = [];
        public static Dictionary<int, object[]> ShipTypes { get; set; } = [];
        public static Dictionary<int, object[]> Pets { get; set; } = [];
        public static Dictionary<int, object[]> Crews { get; set; } = [];
        public static Dictionary<int, object[]> Debuffs { get; set; } = [];
        public static Dictionary<int, object[]> Triggers { get; set; } = [];

        public static Dictionary<int, object[]>[] TraitsDictionaries = new Dictionary<int, object[]>[] {
            PhysicalTrademarks,
            SkinTones,
            HairStyles,
            FacialHairs,
            MainWeapons,
            NatureSkills,
            AdditionalSkills
        };

        public static void CreateDataMaps()
        {
            MoonCycles[1] = new string[] { "New Moon", "A young new pirate, a beginner sailor filled with potential and thirst to learn more." };
            MoonCycles[2] = new string[] { "Waxing Sailor", "A prime pirate, one that has gained enough knowledge to traverse the open seas and dive into the deeper challenges of piracy." };
            MoonCycles[3] = new string[] { "Full Tide", "A pirate in their peak era, one that has garnered sufficient experience, radiating immense command and authority over their crew." };
            MoonCycles[4] = new string[] { "Waning Shadow", "A renowned pirate, respected not just by their crew but also by other pirate crews." };
            MoonCycles[5] = new string[] { "Eclipsed Wander", "A legendary pirate, tested by all the great waves, having vast knowledge and experience of the seas." };

            Forms[1] = new string[] { "Pixie", "Small and extremely agile." };
            Forms[2] = new string[] { "Scout", "Lean and quick." };
            Forms[3] = new string[] { "General", "Steady and average." };
            Forms[4] = new string[] { "Goliath", "Gigantic and imposing." };
            Forms[5] = new string[] { "Colossus", "Monumental and powerful."};

            Types[1] = new string[] { "Necromancy", "Pirate with the skill to resurrect the dead" };
            Types[2] = new string[] { "Blood magic", "Pirates with blood magic can control people to either heal or harm them using their blood." };
            Types[3] = new string[] { "Transmutation", "Pirates with this skill can transform various objects into other things." };
            Types[4] = new string[] { "Alchemy", "These are pirates that are gifted with the knowledge of potion and luck." };
            Types[5] = new string[] { "Teleportation", "These are pirates who are given the ability to teleport to various locations." };

            PirateCodes[1] = new string[] { "Yes", "Can only form allegiance with Pirate who follows the Code." };
            PirateCodes[2] = new string[] { "No", "Can only form allegiance with Pirate who does not follow the Code." };

            PhysicalTrademarks[1] = new object[] { "Missing an eye", "" };
            PhysicalTrademarks[2] = new object[] { "Missing a leg", "" };
            PhysicalTrademarks[3] = new object[] { "Missing an arm", "" };
            PhysicalTrademarks[4] = new object[] { "Tattooed face", "" };
            PhysicalTrademarks[5] = new object[] { "Golden teeth", "" };

            SkinTones[1] = new object[] { "Pale", "" };
            SkinTones[2] = new object[] { "Tanned", "" };
            SkinTones[3] = new object[] { "Dark", "" };
            SkinTones[4] = new object[] { "White", "" };
            SkinTones[5] = new object[] { "Light Brown", "" };

            HairStyles[1] = new object[] { "Long", "" };
            HairStyles[2] = new object[] { "Short", "" };
            HairStyles[3] = new object[] { "Braided", "" };
            HairStyles[4] = new object[] { "Dreadlocks", "" };
            HairStyles[5] = new object[] { "Bald", "" };

            FacialHairs[1] = new object[] { "Beard", "" };
            FacialHairs[2] = new object[] { "Mustache", "" };
            FacialHairs[3] = new object[] { "Goatee", "" };
            FacialHairs[4] = new object[] { "Combined beard and mustache", "" };
            FacialHairs[5] = new object[] { "No facial hair", "" };

            MainWeapons[1] = new object[] { "Bow and Arrow", "Long-ranged weapon; deals damage from a distance. " };
            MainWeapons[2] = new object[] { "Harpoon", "Melee weapon; used for grappling and dealing damage." };
            MainWeapons[3] = new object[] { "Gun", "Ranged weapon; used for powerful and distant damage." };
            MainWeapons[4] = new object[] { "Sword", "Melee weapon; used for close-range combat." };
            MainWeapons[5] = new object[] { "Dagger", "Melee weapon; used for quick attacks and stealth." };

            NatureSkills[1] = new object[] { "Lightning Manipulation", "Provides an ability to control lighting." };
            NatureSkills[2] = new object[] { "Sea Control", "Provides the pirate control over the sea and its waters." };
            NatureSkills[3] = new object[] { "Wind Redirection", "Enables the pirate to redirect wind." };
            NatureSkills[4] = new object[] { "Animal Summoning", "Allows the pirate to summon any animal" };
            NatureSkills[5] = new object[] { "Stormcalling", "Gives a pirate the ability to create storms" };

            AdditionalSkills[1] = new object[] { "", "" };
            AdditionalSkills[2] = new object[] { "", "" };
            AdditionalSkills[3] = new object[] { "", "" };
            AdditionalSkills[4] = new object[] { "", "" };
            AdditionalSkills[5] = new object[] { "", "" };
        }	
	}
}
