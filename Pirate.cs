using System;

namespace CharacterCreationSystem
{
    public abstract class Pirate : IInformation, IAttack, IDefend
    {
        public CharacterStats CharacterStats { get; set; }
        public CharacterTraits CharacterTraits { get; set; }
        public CharacterInfo CharacterInfo { get; set; }

        public Pirate(string name, string moonCycles, string form, bool pirateCode, string pirateType)
        {
            this.CharacterInfo = new CharacterInfo(name, moonCycles, form, pirateCode, pirateType);
            this.CharacterTraits = new CharacterTraits();
            this.CharacterStats = new CharacterStats();
        }
        public abstract void MainWeapon();
        public abstract void SecondarySkill();
        public abstract void NaturalSkill();
        public abstract void AdditionalSkill();
    }
}