using System;

namespace CharacterCreationSystem
{
    public abstract class Pirate : IInformation, IAttack
    {
        public CharacterStats CharacterStats { get; set; }
        public CharacterInfo CharacterInfo { get; set; }
        public CharacterWeapons CharacterWeapons { get; set; }
        public CharacterTraits CharacterTraits { get; set; }

        public Pirate(Element secondarySkill)
        {
            this.CharacterStats = new CharacterStats();
            this.CharacterInfo = new CharacterInfo();
            this.CharacterWeapons = new CharacterWeapons();
            this.CharacterTraits = new CharacterTraits();
        }

        public abstract void MainAttack();
        public abstract void SecondAttack();
        public abstract void NatureAttack();
        public abstract void AdditionalAttack();
    }
}