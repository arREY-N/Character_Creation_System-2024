using System;

namespace CharacterCreationSystem
{
    // Interface to define what information should be included in each character
    public interface IInformation
    {
        CharacterInfo CharacterInfo { get; set; }
        CharacterStats CharacterStats { get; set; }
        CharacterTraits CharacterTraits { get; set; }
        public abstract void SetDefaultStats(int agility, int charisma, int health, int intelligence, int strength);
    }
    // Interface to define all the attack methods each character should implement
    public interface IAttack
    {
        void MainAttack();
        void SecondAttack();
        void NatureAttack();
        void AdditionalAttack();
    }
}