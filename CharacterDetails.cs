using System;

namespace CharacterCreationSystem
{
    public struct CharacterInfo
    {
        public string Name { get; set; }
        public string MoonCycles { get; set; }
        public string Form { get; set; }
        public bool PirateCode { get; set; }
        public string PirateType { get; set; }

        public CharacterInfo(string name, string moonCycles, string form, bool pirateCode, string pirateType)
        {
            this.Name = name;
            this.MoonCycles = moonCycles;
            this.Form = form;
            this.PirateCode = pirateCode;
            this.PirateType = pirateType;
        }
    }

    public class CharacterStats
    {
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
    }

    public class CharacterTraits
    {
        public string? PhysicalTrademark { get; set; }
        public string? SkinTone { get; set; }
        public string? HairStyle { get; set; }
        public string? FacialHair { get; set; }
        public string? MainSkill { get; set; }
        public string? SecondarySkill { get; set; }
        public string? NatureSkill { get; set; }
        public string? AdditionalSkill { get; set; }
        public string? BaseClothing { get; set; }
        public string? Accessories { get; set; }
        public string? PirateOrigin { get; set; }
        public string? ShipType { get; set; }
        public string? ShipSize { get; set; }
        public string? Pet { get; set; }
        public string? Crew { get; set; }
        public string? Trigger { get; set; }
        public string? Debuff { get; set; }
    }
}