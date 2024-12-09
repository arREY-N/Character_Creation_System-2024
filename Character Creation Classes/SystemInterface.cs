using System;

namespace CharacterCreationSystem
{
    public interface IInformation
    {
        CharacterInfo CharacterInfo { get; set; }
        CharacterStats CharacterStats { get; set; }
        CharacterTraits CharacterTraits { get; set; }
        public abstract void SetDefaultStats(int agility, int charisma, int health, int intelligence, int strength);
    }

    public interface IAttack
    {
        void MainAttack();
        void SecondAttack();
        void NatureAttack();
        void AdditionalAttack();
    }

    public interface IDefend
    {

    }

    public interface IHeal
    {

    }
}